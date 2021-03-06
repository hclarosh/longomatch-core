﻿//
//  Copyright (C) 2015 Andoni Morales Alastruey
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
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Couchbase.Lite;
using LongoMatch.Core.Store;
using LongoMatch.Core.Store.Templates;
using LongoMatch.DB;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using VAS.Core.Common;
using VAS.Core.Interfaces;
using VAS.Core.Serialization;
using VAS.Core.Store;
using VAS.Core.Store.Templates;
using VAS.DB;
using VAS.DB.Views;

namespace Tests.DB
{
	class StorableContainerTest : StorableBase
	{
		public StorableContainerTest ()
		{
			ID = Guid.NewGuid ();
		}

		public StorableImageTest Image { get; set; }
	}

	class StorableListTest : StorableBase
	{
		public StorableListTest ()
		{
			ID = Guid.NewGuid ();
		}

		public List<StorableImageTest> Images { get; set; }
	}

	class StorableListNoChildrenTest : StorableListTest
	{
		public override bool DeleteChildren {
			get {
				return false;
			}
		}
	}


	class StorableImageTest : StorableBase
	{
		public StorableImageTest ()
		{
			ID = Guid.NewGuid ();
		}

		public Image Image1 { get; set; }

		public Image Image2 { get; set; }

		public List<Image> Images { get; set; }
	}

	class StorableImageTest2 : StorableImageTest
	{
	}

	class StorableView : GenericView<IStorable>
	{
		public StorableView (CouchbaseStorage storage) : base (storage)
		{
		}

		protected override string ViewVersion {
			get {
				return "1";
			}
		}
	}

	[TestFixture ()]
	public class TestStorage
	{
		Database db;
		IStorage storage;

		[OneTimeSetUp]
		public void InitDB ()
		{
			string tmpPath = Path.GetTempPath ();
			string homePath = Path.Combine (tmpPath, "LongoMatch");
			string dbPath = Path.Combine (homePath, "db");
			if (Directory.Exists (dbPath)) {
				Directory.Delete (dbPath, true);
			}

			Directory.CreateDirectory (tmpPath);
			Directory.CreateDirectory (homePath);
			Directory.CreateDirectory (dbPath);

			storage = new CouchbaseStorageLongoMatch (dbPath, "test-db");
			db = ((CouchbaseStorageLongoMatch)storage).Database;
			// Remove the StorageInfo doc to get more understandable document count results
			db.GetDocument (Guid.Empty.ToString ()).Delete ();

			Environment.SetEnvironmentVariable ("LONGOMATCH_HOME", tmpPath);
			Environment.SetEnvironmentVariable ("LGM_UNINSTALLED", "1");
		}

		[OneTimeTearDown]
		public void DeleteDB ()
		{
			Directory.Delete (db.Manager.Directory, true);
		}

		[TearDown]
		public void CleanDB ()
		{
			db.RunInTransaction (() => {
				foreach (var d in db.CreateAllDocumentsQuery ().Run ()) {
					db.GetDocument (d.DocumentId).Delete ();
				}
				return true;
			});
		}

		[Test ()]
		public void TestIsChangedResetted ()
		{
			LMTeam t, t1;
			ObjectChangedParser parser;
			List<IStorable> storables = null, changed = null;
			StorableNode parent = null;

			parser = new ObjectChangedParser ();
			t = LMTeam.DefaultTemplate (10);
			storage.Store (t);

			// After loading an object
			t1 = DocumentsSerializer.LoadObject (typeof (LMTeam), t.ID, db) as LMTeam;
			Assert.IsTrue (parser.ParseInternal (out parent, t1, Serializer.JsonSettings));
			Assert.IsTrue (parent.ParseTree (ref storables, ref changed));
			Assert.AreEqual (0, changed.Count);
			Assert.NotNull (t1.DocumentID);

			// After filling an object
			t1 = new LMTeam ();
			t1.ID = t.ID;
			t1.DocumentID = t.ID.ToString ();
			t1.IsChanged = true;
			DocumentsSerializer.FillObject (t1, db);
			Assert.IsTrue (parser.ParseInternal (out parent, t1, Serializer.JsonSettings));
			Assert.IsTrue (parent.ParseTree (ref storables, ref changed));
			Assert.AreEqual (0, changed.Count);
		}

		[Test ()]
		public void TestDashboards ()
		{
			LMDashboard dashboard = LMDashboard.DefaultTemplate (10);
			dashboard.Image = dashboard.FieldBackground = dashboard.HalfFieldBackground =
				dashboard.GoalBackground = Utils.LoadImageFromFile ();
			storage.Store (dashboard);
			Assert.AreEqual (17, db.DocumentCount);
			Assert.IsNotNull (db.GetExistingDocument (dashboard.ID.ToString ()));
			Dashboard dashboard2 = storage.Retrieve<Dashboard> (dashboard.ID);
			Assert.IsNotNull (dashboard2);
			Assert.AreEqual (dashboard.ID, dashboard2.ID);
			Assert.AreEqual (dashboard.List.Count, dashboard2.List.Count);
			Assert.IsNotNull (dashboard2.Image);
			Assert.IsNotNull (dashboard2.FieldBackground);
			Assert.IsNotNull (dashboard2.HalfFieldBackground);
			Assert.IsNotNull (dashboard2.GoalBackground);
			Assert.IsNotNull (dashboard2.DocumentID);
			Assert.AreEqual (16, dashboard2.Image.Width);
			Assert.AreEqual (16, dashboard2.Image.Height);
			storage.Delete (dashboard);
			Assert.AreEqual (1, db.DocumentCount);
		}

		[Test ()]
		public void TestPlayer ()
		{
			LMPlayer player1 = new LMPlayer {
				Name = "andoni", Position = "runner",
				Number = 5, Birthday = new DateTime (1984, 6, 11),
				Nationality = "spanish", Height = 1.73f, Weight = 70,
				Playing = true, Mail = "test@test", Color = Color.Red
			};
			player1.Photo = Utils.LoadImageFromFile ();
			storage.Store (player1);
			Assert.AreEqual (2, db.DocumentCount);
			Assert.IsNotNull (db.GetExistingDocument (player1.ID.ToString ()));
			LMPlayer player2 = storage.Retrieve<LMPlayer> (player1.ID);
			Assert.AreEqual (player1.ID, player2.ID);
			Assert.AreEqual (player1.ToString (), player2.ToString ());
			Assert.AreEqual (player1.Photo.Width, player2.Photo.Width);
			Assert.IsNotNull (player2.DocumentID);
			storage.Delete (player1);
			Assert.AreEqual (1, db.DocumentCount);
		}

		[Test ()]
		public void TestTeam ()
		{
			LMTeam team1 = LMTeam.DefaultTemplate (10);
			storage.Store<LMTeam> (team1);
			Assert.AreEqual (12, db.DocumentCount);
			LMTeam team2 = storage.Retrieve<LMTeam> (team1.ID);
			Assert.AreEqual (team1.ID, team2.ID);
			Assert.AreEqual (team1.List.Count, team2.List.Count);
			Assert.IsNotNull (team2.DocumentID);
			storage.Delete (team1);
			Assert.AreEqual (1, db.DocumentCount);
		}

		[Test ()]
		public void TestTimelineEvent ()
		{
			LMPlayer p = new LMPlayer ();
			AnalysisEventType evtType = new AnalysisEventType ();
			LMTimelineEvent evt = new LMTimelineEvent ();

			Document doc = db.GetDocument (evt.ID.ToString ());
			SerializationContext context = new SerializationContext (db, evt.GetType ());
			context.Cache.AddReference (p);
			evt.Players.Add (p);
			evt.EventType = evtType;

			doc.Update ((UnsavedRevision rev) => {
				JObject jo = DocumentsSerializer.SerializeObject (evt, rev, context);
				Assert.AreEqual (p.ID.ToString (), jo ["Players"] [0].Value<String> ());
				Assert.AreEqual (evtType.ID.ToString (), jo ["EventType"].Value<String> ());
				IDictionary<string, object> props = jo.ToObject<IDictionary<string, object>> ();
				rev.SetProperties (props);
				return true;
			});

			/* LMPlayer has not been added to the db, as it was already referenced
			 * by the IDReferenceResolver */
			Assert.AreEqual (2, db.DocumentCount);

			DocumentsSerializer.SaveObject (p, db);
			Assert.AreEqual (3, db.DocumentCount);

			LMTimelineEvent evt2 = storage.Retrieve<LMTimelineEvent> (evt.ID);
			Assert.IsNotNull (evt2.EventType);
			Assert.IsNotNull (evt2.DocumentID);

			storage.Delete (evt);
			Assert.AreEqual (3, db.DocumentCount);
			storage.Delete (p);
			Assert.AreEqual (2, db.DocumentCount);
			storage.Delete (evtType);
			Assert.AreEqual (1, db.DocumentCount);
		}

		[Test ()]
		public void TestProject ()
		{
			LMProject p = new LMProject ();
			p.Dashboard = LMDashboard.DefaultTemplate (10);
			p.UpdateEventTypesAndTimers ();
			p.LocalTeamTemplate = LMTeam.DefaultTemplate (10);
			p.VisitorTeamTemplate = LMTeam.DefaultTemplate (12);
			MediaFile mf = new MediaFile ("path", 34000, 25, true, true, "mp4", "h264",
							   "aac", 320, 240, 1.3, null, "Test asset");
			var pd = new ProjectDescription ();
			pd.FileSet = new MediaFileSet ();
			pd.FileSet.Add (mf);
			p.Description = pd;
			p.AddEvent (new LMTimelineEvent ());

			storage.Store<LMProject> (p);
			Assert.AreEqual (45, db.DocumentCount);

			p = storage.RetrieveAll<LMProject> ().First ();
			Assert.IsNotNull (p.DocumentID);
			p.Load ();
			Assert.IsTrue (Object.ReferenceEquals (p.Description.FileSet, p.Timeline [0].FileSet));
			storage.Store (p);
			Assert.AreEqual (45, db.DocumentCount);

			storage.Delete (p);
			Assert.AreEqual (1, db.DocumentCount);
		}


		[Test ()]
		public void TestSaveProjectWithEvents ()
		{
			LMProject p = new LMProject ();
			p.Dashboard = LMDashboard.DefaultTemplate (10);
			p.UpdateEventTypesAndTimers ();
			p.LocalTeamTemplate = LMTeam.DefaultTemplate (10);
			p.VisitorTeamTemplate = LMTeam.DefaultTemplate (12);
			MediaFile mf = new MediaFile ("path", 34000, 25, true, true, "mp4", "h264",
							   "aac", 320, 240, 1.3, null, "Test asset");
			var pd = new ProjectDescription ();
			pd.FileSet = new MediaFileSet ();
			pd.FileSet.Add (mf);
			p.Description = pd;

			for (int i = 0; i < 10; i++) {
				LMTimelineEvent evt = new LMTimelineEvent {
					EventType = p.EventTypes [i],
					Start = new Time (1000),
					Stop = new Time (2000),
				};
				evt.Players.Add (p.LocalTeamTemplate.Players [0]);
				p.Timeline.Add (evt);
			}

			storage.Store<LMProject> (p);
			Assert.AreEqual (54, db.DocumentCount);
			storage.Store<LMProject> (p);
			Assert.AreEqual (54, db.DocumentCount);

			LMProject p2 = storage.Retrieve<LMProject> (p.ID);
			Assert.AreEqual (p.Timeline.Count, p2.Timeline.Count);
			Assert.AreEqual (p2.LocalTeamTemplate.List [0], p2.Timeline [0].Players [0]);
			Assert.AreEqual ((p2.Dashboard.List [0] as AnalysisEventButton).EventType,
				p2.Timeline [0].EventType);
			Assert.IsNotNull (p2.DocumentID);

			storage.Delete (p);
			Assert.AreEqual (1, db.DocumentCount);
		}

		[Test ()]
		public void TestDeleteProjectItems ()
		{
			LMProject p = new LMProject ();
			p.Dashboard = LMDashboard.DefaultTemplate (10);
			p.UpdateEventTypesAndTimers ();
			p.LocalTeamTemplate = LMTeam.DefaultTemplate (10);

			for (int i = 0; i < 10; i++) {
				LMTimelineEvent evt = new LMTimelineEvent {
					EventType = p.EventTypes [i],
					Start = new Time (1000),
					Stop = new Time (2000),
				};
				p.Timeline.Add (evt);
			}

			storage.Store (p);
			p = storage.Retrieve<LMProject> (p.ID);

			// Removing this object should not remove the EvenType from the database, which might be referenced by
			// LMTimelineEvent's in the timeline
			EventType evtType = (p.Dashboard.List [0] as AnalysisEventButton).EventType;
			p.Dashboard.List.Remove (p.Dashboard.List [0]);
			storage.Store (p);
			Assert.DoesNotThrow (() => storage.Retrieve<LMProject> (p.ID));

			// Delete an event with a LMPlayer, a Team and an EventType, it should delete only the timeline event
			p.Timeline [0].Teams.Add (p.LocalTeamTemplate);
			p.Timeline [0].Players.Add (p.LocalTeamTemplate.List [0]);
			p.Timeline.Remove (p.Timeline [0]);
			Assert.DoesNotThrow (() => storage.Retrieve<LMProject> (p.ID));
		}

		[Test ()]
		public void TestPreloadPropertiesArePreserved ()
		{
			LMProject p1 = Utils.CreateProject (true);
			storage.Store (p1);
			LMProject p2 = storage.RetrieveAll<LMProject> ().First ();
			Assert.IsFalse (p2.IsLoaded);
			Assert.IsNotNull (p2.DocumentID);
			p2.Description.Competition = "NEW NAME";
			p2.Load ();
			Assert.AreEqual ("NEW NAME", p2.Description.Competition);
			storage.Store (p2);
			LMProject p3 = storage.RetrieveAll<LMProject> ().First ();
			Assert.IsNotNull (p3.DocumentID);
			Assert.AreEqual (p2.Description.Competition, p3.Description.Competition);
		}

		[Test ()]
		public void TestExists ()
		{
			LMProject p1 = Utils.CreateProject (true);
			LMProject p2 = Utils.CreateProject (true);
			storage.Store (p1);

			var exists = storage.Exists<LMProject> (p1);
			var notExists = storage.Exists<LMProject> (p2);
			Assert.IsTrue (exists);
			Assert.IsFalse (notExists);

			var existsEvent = storage.Exists<LMTimelineEvent> (p1.Timeline.ElementAt (0) as LMTimelineEvent);
			var notExistsEvent = storage.Exists<LMTimelineEvent> (p2.Timeline.ElementAt (0) as LMTimelineEvent);
			Assert.IsTrue (existsEvent);
			Assert.IsFalse (notExistsEvent);
		}

		[Test ()]
		public void TestCount ()
		{
			LMProject p1 = Utils.CreateProject (true);
			LMProject p2 = Utils.CreateProject (false);
			Assert.AreEqual (0, storage.Count<LMProject> ());
			Assert.AreEqual (0, storage.Count<LMTimelineEvent> ());
			storage.Store (p1);
			Assert.AreEqual (1, storage.Count<LMProject> ());
			Assert.AreEqual (3, storage.Count<LMTimelineEvent> ());
			storage.Store (p2);
			Assert.AreEqual (2, storage.Count<LMProject> ());
			Assert.AreEqual (3, storage.Count<LMTimelineEvent> ());
		}
	}
}
