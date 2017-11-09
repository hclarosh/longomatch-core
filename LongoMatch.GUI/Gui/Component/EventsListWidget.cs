//
//  Copyright (C) 2014 Andoni Morales Alastruey
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
using LongoMatch.Core.Common;
using LongoMatch.Core.Store;
using LongoMatch.Core.ViewModel;
using VAS.Core;
using VAS.Core.Common;
using VAS.Core.Interfaces.MVVMC;
using VAS.Core.Resources.Styles;
using Helpers = VAS.UI.Helpers;

namespace LongoMatch.Gui.Component
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class EventsListWidget : Gtk.Bin, IView<LMProjectVM>
	{
		LMTimelineEventsTreeView playsList;
		TeamTimelineEventsTreeView homeTeamTreeView, awayTeamTreeView;
		LMProjectVM viewModel;
		Helpers.IconNotebookHelper notebookHelper;

		public EventsListWidget ()
		{
			this.Build ();
			playsnotebook.Page = 0;
			playsList1.HeightRequest = Sizes.PlayerCapturerControlsHeight;

			playsList = new LMTimelineEventsTreeView ();
			playsList.Show ();
			eventsScrolledWindow.Add (playsList);
			homeTeamTreeView = new TeamTimelineEventsTreeView (TeamType.LOCAL);
			homeTeamTreeView.Show ();
			homescrolledwindow.Add (homeTeamTreeView);
			awayTeamTreeView = new TeamTimelineEventsTreeView (TeamType.VISITOR);
			awayTeamTreeView.Show ();
			awayscrolledwindow.Add (awayTeamTreeView);
		}

		public override void Dispose ()
		{
			Dispose (true);
			base.Dispose ();
		}

		protected virtual void Dispose (bool disposing)
		{
			if (Disposed) {
				return;
			}
			if (disposing) {
				Destroy ();
			}
			Disposed = true;
		}

		protected bool Disposed { get; private set; } = false;

		protected override void OnDestroyed ()
		{
			ViewModel = null;
			playsList1.Dispose ();
			limitationWidget.Dispose ();
			base.OnDestroyed ();
			Disposed = true;
		}

		public LMProjectVM ViewModel {
			get {
				return viewModel;
			}
			set {
				viewModel = value;
				playsList.ViewModel = viewModel?.Timeline;
				playsList.Project = viewModel;
				homeTeamTreeView.ViewModel = viewModel?.Timeline;
				homeTeamTreeView.Project = viewModel;
				awayTeamTreeView.ViewModel = viewModel?.Timeline;
				awayTeamTreeView.Project = viewModel;
				limitationWidget.ViewModel = viewModel?.Timeline?.LimitationChart;
				if (viewModel != null) {
					LoadIcons ();
				}
			}
		}

		public void SetViewModel (object viewModel)
		{
			ViewModel = viewModel as LMProjectVM;
		}

		void LoadIcons ()
		{
			LMProject project = ViewModel.Model;
			notebookHelper = new Helpers.IconNotebookHelper (playsnotebook);
			notebookHelper.SetTabIcon (eventsScrolledWindow, "vas-category", "vas-category",
				Catalog.GetString ("Both Teams"));
			if (project.LocalTeamTemplate.Shield != null) {
				var localIcon = project.LocalTeamTemplate.Shield;
				notebookHelper.SetTabIcon (homescrolledwindow, localIcon, localIcon, project.LocalTeamTemplate.Name);
			} else {
				notebookHelper.SetTabIcon (homescrolledwindow, "vas-default-shield", "vas-default-shield",
					project.LocalTeamTemplate.Name);
			}

			if (project.VisitorTeamTemplate.Shield != null) {
				var visitorIcon = project.VisitorTeamTemplate.Shield;
				notebookHelper.SetTabIcon (awayscrolledwindow, visitorIcon, visitorIcon, project.VisitorTeamTemplate.Name);
			} else {
				notebookHelper.SetTabIcon (awayscrolledwindow, "vas-default-shield", "vas-default-shield",
					project.VisitorTeamTemplate.Name);
			}

			notebookHelper.UpdateTabs ();
		}
	}
}
