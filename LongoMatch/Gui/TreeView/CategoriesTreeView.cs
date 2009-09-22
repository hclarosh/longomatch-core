// TreeWidgetPopup.cs
//
//  Copyright (C) 2007-2009 Andoni Morales Alastruey
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301, USA.
//
//

using System;
using Gdk;
using Gtk;
using Mono.Unix;
using LongoMatch.Handlers;
using LongoMatch.TimeNodes;

namespace LongoMatch.Gui.Component
{
	
	public delegate void SectionHandler (SectionsTimeNode tNode);
	
	[System.ComponentModel.Category("LongoMatch")]
	[System.ComponentModel.ToolboxItem(true)]
	public class CategoriesTreeView : Gtk.TreeView
	{
		public event SectionHandler SectionClicked;
		public event SectionHandler SectionSelected;
		
		public CategoriesTreeView(){
			
			RowActivated += OnTreeviewRowActivated;
			CursorChanged += OnCursorChanged;
			
			Gtk.TreeViewColumn nameColumn = new Gtk.TreeViewColumn ();
			nameColumn.Title = Catalog.GetString("Name");
			Gtk.CellRendererText nameCell = new Gtk.CellRendererText ();
			nameColumn.PackStart (nameCell, true);

			Gtk.TreeViewColumn startTimeColumn = new Gtk.TreeViewColumn ();
			startTimeColumn.Title = Catalog.GetString("Lead Time");
			Gtk.CellRendererText startTimeCell = new Gtk.CellRendererText ();
			startTimeColumn.PackStart (startTimeCell, true);
			
			Gtk.TreeViewColumn stopTimeColumn = new Gtk.TreeViewColumn ();
			stopTimeColumn.Title = Catalog.GetString("Lag Time");
			Gtk.CellRendererText stopTimeCell = new Gtk.CellRendererText ();
			stopTimeColumn.PackStart (stopTimeCell, true);		
			
			Gtk.TreeViewColumn colorColumn = new Gtk.TreeViewColumn ();
			colorColumn.Title = Catalog.GetString("Color");
			Gtk.CellRendererText colorCell = new Gtk.CellRendererText ();
			colorColumn.PackStart (colorCell, true);
			
			Gtk.TreeViewColumn hotKeyColumn = new Gtk.TreeViewColumn ();
			hotKeyColumn.Title = Catalog.GetString("Hotkey");
			Gtk.CellRendererText hotKeyCell = new Gtk.CellRendererText ();
			hotKeyColumn.PackStart (hotKeyCell, true);
	
			nameColumn.SetCellDataFunc (nameCell, new Gtk.TreeCellDataFunc (RenderName));
			startTimeColumn.SetCellDataFunc (startTimeCell, new Gtk.TreeCellDataFunc (RenderStartTime));
			stopTimeColumn.SetCellDataFunc (stopTimeCell, new Gtk.TreeCellDataFunc (RenderStopTime));
			colorColumn.SetCellDataFunc(colorCell, new Gtk.TreeCellDataFunc(RenderColor));
			hotKeyColumn.SetCellDataFunc(hotKeyCell, new Gtk.TreeCellDataFunc(RenderHotKey));

			AppendColumn (nameColumn);
			AppendColumn (startTimeColumn);
			AppendColumn (stopTimeColumn);
			AppendColumn(colorColumn);
			AppendColumn(hotKeyColumn);		
		}					
			
		private void RenderName (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			SectionsTimeNode tNode = (SectionsTimeNode) model.GetValue (iter, 0);
	 
			(cell as Gtk.CellRendererText).Text = tNode.Name;						
		}
 
		
		private void RenderStartTime (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			SectionsTimeNode tNode = (SectionsTimeNode) model.GetValue (iter, 0);
			
			(cell as Gtk.CellRendererText).Text =tNode.Start.Seconds.ToString();
		}
		
		private void RenderStopTime (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			SectionsTimeNode tNode = (SectionsTimeNode) model.GetValue (iter, 0);
			
			(cell as Gtk.CellRendererText).Text = tNode.Stop.Seconds.ToString();
		}	
		
		private void RenderColor (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			SectionsTimeNode tNode = (SectionsTimeNode) model.GetValue (iter, 0);
			
			(cell as Gtk.CellRendererText).CellBackgroundGdk = tNode.Color;
		}	
		
		private void RenderHotKey (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			SectionsTimeNode tNode = (SectionsTimeNode) Model.GetValue (iter, 0);
			
			(cell as Gtk.CellRendererText).Text = tNode.HotKey.ToString();			
		}	
		
		protected virtual void OnCursorChanged (object o, System.EventArgs e){
			TreeIter iter;
			Selection.GetSelected(out iter);
			SectionsTimeNode tNode = (SectionsTimeNode) Model.GetValue (iter, 0);
			if (SectionSelected != null)
				SectionSelected(tNode);
		}
		
		protected virtual void OnTreeviewRowActivated(object o, Gtk.RowActivatedArgs args)
		{
			Gtk.TreeIter iter;
			Model.GetIter (out iter, args.Path);
			SectionsTimeNode tNode = (SectionsTimeNode)Model.GetValue (iter, 0);
			
			if (SectionClicked != null)
				SectionClicked(tNode);				
		}
	}
}