//
//  Copyright (C) 2013 Andoni Morales Alastruey
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

using LongoMatch.Core.Store;
using Gtk;
using Mono.Unix;
using LongoMatch.Core.Store.Templates;
using LongoMatch.Core.Stats;
using LongoMatch.Core.Common;

namespace LongoMatch.Gui.Component.Stats
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class PlayersViewer : Gtk.Bin
	{
		TreeStore store;
		ProjectStats pstats;
		EventsFilter filter;
		Player current;
		
		public PlayersViewer ()
		{
			this.Build ();
			store = new TreeStore(typeof(string), typeof(object));
			treeview1.AppendColumn ("Desc", new Gtk.CellRendererText (), "text", 0);
			treeview1.CursorChanged += HandleCursorChanged;
			treeview1.Model = store;
			treeview1.HeadersVisible = false;
			treeview1.EnableGridLines = TreeViewGridLines.None;
			treeview1.EnableTreeLines = false;
		}
		
		public void LoadProject (Project project, ProjectStats stats) {
			TreePath path;
			
			store.Clear();
			pstats = stats;
			categoriesviewer.LoadStats (pstats, project);
			AddTeam (project.LocalTeamTemplate, project.Dashboard);
			AddTeam (project.VisitorTeamTemplate, project.Dashboard);
			path = new TreePath ("0:0");
			treeview1.ExpandAll ();
			treeview1.SetCursor (path, null, false);
		}
		
		void AddTeam (TeamTemplate tpl, Dashboard cats)
		{
			TreeIter iter = store.AppendValues (tpl.TeamName, null);
			foreach (Player p in tpl.List) {
				store.AppendValues (iter, p.Name, p);
			}
		}
		
		void HandleCursorChanged (object sender, EventArgs e)
		{
			TreeIter iter;
			
			treeview1.Selection.GetSelected(out iter);
			current = store.GetValue(iter, 1) as Player;
			if (current != null) {
				categoriesviewer.ReloadStats (current);
			}
		}
	}
}

