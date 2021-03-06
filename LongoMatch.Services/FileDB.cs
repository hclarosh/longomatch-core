// 
//  Copyright (C) 2011 Andoni Morales Alastruey
// 
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301, USA.
// 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LongoMatch.Core.Common;
using LongoMatch.Core.Interfaces;
using LongoMatch.Core.Store;

namespace LongoMatch.DB
{
	public class DataBase: IDatabase
	{
		LiteDB projectsDB;
		string dbDirPath;
		string dbPath;
		string dbName;
		TimeSpan maxDaysWithoutBackup = new TimeSpan (5, 0, 0, 0);
		ISerializer serializer;

		public ISerializer SerializerObject {
			get {
				return serializer;
			}
			set {
				serializer = value;
			}
		}

		public DataBase (string dbDirPath)
		{
			serializer = new Serializer ();

			dbName = Path.GetFileNameWithoutExtension (dbDirPath);
			dbPath = Path.Combine (dbDirPath, Path.GetFileName (dbDirPath));
			this.dbDirPath = dbDirPath;
			
			if (!Directory.Exists (dbDirPath)) {
				Directory.CreateDirectory (dbDirPath);
			}
			if (File.Exists (dbPath)) {
				try {
					projectsDB = serializer.Load<LiteDB> (dbPath);
					projectsDB.DBPath = dbPath;
				} catch (Exception e) {
					Log.Exception (e);
				}
			}
			if (projectsDB == null) {
				Reload ();
			}
			DateTime now = DateTime.UtcNow;
			if (projectsDB.LastBackup + maxDaysWithoutBackup < now) {
				Backup ();
			}
		}

		/// <value>
		/// The database version
		/// </value>
		public Version Version {
			get {
				return projectsDB.Version;
			}
			set {
				projectsDB.Version = value;
			}
		}

		public string Name {
			get {
				return dbName;
			}
		}

		public DateTime LastBackup {
			get {
				return projectsDB.LastBackup;
			}
		}

		public int Count {
			get {
				return projectsDB.Projects.Count;
			}
		}

		public bool Exists (Project project)
		{
			bool ret = false;
			if (projectsDB.ProjectsDict.ContainsKey (project.ID)) {
				if (File.Exists (Path.Combine (dbDirPath, project.ID.ToString ()))) {
					ret = true;
				}
			}
			return ret;
		}

		public bool Backup ()
		{
			DirectoryInfo backupDir, dbDir;
			FileInfo[] files;
			
			dbDir = new DirectoryInfo (dbDirPath);
			backupDir = new DirectoryInfo (dbDirPath + ".backup");
			try {
				if (backupDir.Exists) {
					backupDir.Delete (true);
				}
				backupDir.Create ();
				files = dbDir.GetFiles ();
				foreach (FileInfo file in files) {
					string temppath = Path.Combine (backupDir.FullName, file.Name);
					file.CopyTo (temppath, false);
				}
				projectsDB.LastBackup = DateTime.UtcNow;
				projectsDB.Save ();
				return true;
			} catch (Exception ex) {
				Log.Exception (ex);
				return false;
			}
		}

		public bool Delete ()
		{
			try {
				Directory.Delete (dbDirPath, true);
				return true;
			} catch (Exception ex) {
				Log.Exception (ex);
				return false;
			}
		}

		public List<ProjectDescription> GetAllProjects ()
		{
			return projectsDB.Projects;
		}

		public Project GetProject (Guid id)
		{
			string projectFile = Path.Combine (dbDirPath, id.ToString ());

			if (File.Exists (projectFile)) {
				try {
					return serializer.Load<Project> (projectFile);
				} catch (Exception ex) {
					throw new ProjectDeserializationException (ex);
				}
			} else {
				throw new ProjectNotFoundException (projectFile);
			}
		}

		public void AddProject (Project project)
		{
			string projectFile;
			bool update = false;

			Log.Debug (string.Format ("Add project {0}", project.ID));
			projectFile = Path.Combine (dbDirPath, project.ID.ToString ());
			string tmpProjectFile = projectFile + ".tmp";
			project.Description.LastModified = DateTime.UtcNow;
			if (projectsDB.ProjectsDict.ContainsKey (project.Description.ProjectID)) {
				update = true;
			}

			projectsDB.Add (project.Description);
			try {
				serializer.Save (project, tmpProjectFile);
				if (File.Exists (projectFile))
					File.Replace (tmpProjectFile, projectFile, null);
				else {
					File.Move (tmpProjectFile, projectFile);
				}
			} catch (Exception ex) {
				Log.Exception (ex);
				// FIXME: This is dirty, but I can't find another way right now.
				if (!update) {
					projectsDB.Delete (project.Description.ProjectID);
				}
				throw;
			}
		}

		public bool RemoveProject (Guid id)
		{
			string projectFile;

			Log.Debug (string.Format ("Remove project {0}", id));
			projectFile = Path.Combine (dbDirPath, id.ToString ());
			if (File.Exists (projectFile)) {
				File.Delete (projectFile);
			}
			return projectsDB.Delete (id);
		}

		public void UpdateProject (Project project)
		{
			Log.Debug (string.Format ("Update project {0}", project.ID));
			project.ConsolidateDescription ();
			AddProject (project);
		}

		public void Reload ()
		{
			projectsDB = new LiteDB (dbPath);
			DirectoryInfo dbDir = new DirectoryInfo (dbDirPath);
			foreach (FileInfo file in dbDir.GetFiles ()) {
				if (file.FullName == dbPath) {
					continue;
				}
				try {
					Project project = serializer.Load<Project> (file.FullName);
					projectsDB.Add (project.Description);
				} catch (Exception ex) {
					Log.Exception (ex);
				}
			}
			projectsDB.Save ();
		}
	}

	[Serializable]
	class LiteDB
	{
		static ISerializer serializer = new Serializer ();

		public LiteDB (string dbPath)
		{
			DBPath = dbPath;
			ProjectsDict = new Dictionary <Guid, ProjectDescription> ();
			Version = new System.Version (Constants.DB_MAYOR_VERSION,
				Constants.DB_MINOR_VERSION);
			LastBackup = DateTime.UtcNow;
		}

		public LiteDB ()
		{
		}

		public string DBPath {
			get;
			set;
		}

		public Version Version { get; set; }

		public Dictionary<Guid, ProjectDescription> ProjectsDict { get; set; }

		public DateTime LastBackup { get; set; }

		public List<ProjectDescription> Projects {
			get {
				return ProjectsDict.Select (d => d.Value).ToList ();
			}
		}

		public bool Add (ProjectDescription desc)
		{
			if (ProjectsDict.ContainsKey (desc.ProjectID)) {
				ProjectsDict [desc.ProjectID] = desc;
			} else {
				ProjectsDict.Add (desc.ProjectID, desc);
			}
			return Save ();
		}

		public bool Delete (Guid uuid)
		{
			if (ProjectsDict.ContainsKey (uuid)) {
				ProjectsDict.Remove (uuid);
				return Save ();
			}
			return false;
		}

		public bool Save ()
		{
			bool ret = false;
			
			try {
				serializer.Save (this, DBPath);
				ret = true;
			} catch (Exception ex) {
				Log.Exception (ex);
			}
			return ret;
		}
	}
}

