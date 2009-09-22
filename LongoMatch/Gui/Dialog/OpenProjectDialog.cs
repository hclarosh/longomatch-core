// OpenProjectDialog.cs
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
using Gtk;
using LongoMatch.DB;

namespace LongoMatch.Gui.Dialog
{
	
	[System.ComponentModel.Category("LongoMatch")]
	[System.ComponentModel.ToolboxItem(false)]
	public partial class OpenProjectDialog : Gtk.Dialog
	{


		
		public OpenProjectDialog()
		{
			this.Build();
			this.Fill();
			
		}
			
		
		public Project GetSelection(){
			return projectlistwidget.GetSelection();			
		}
		
		public void Fill(){
			projectlistwidget.Fill(MainClass.DB.GetAllDB());
		}

		protected virtual void OnFiledatalistwidgetProjectSelectedEvent (Project project)
		{
			this.buttonOk.Activate();
		}


	}
}
