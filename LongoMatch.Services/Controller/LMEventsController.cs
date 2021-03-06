// EventsManager.cs
//
//  Copyright (C2007-2009 Andoni Morales Alastruey
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
//Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301, USA.
//
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LongoMatch.Core.Common;
using LongoMatch.Core.Events;
using LongoMatch.Core.Store;
using LongoMatch.Services.State;
using LongoMatch.Services.ViewModel;
using VAS.Core.Common;
using VAS.Core.Events;
using VAS.Core.Interfaces.MVVMC;
using VAS.Core.MVVMC;
using VAS.Core.Store;
using VAS.Services.Controller;
using LMKeyAction = LongoMatch.Core.Common.KeyAction;

namespace LongoMatch.Services
{
	[Controller (ProjectAnalysisState.NAME)]
	[Controller (FakeLiveProjectAnalysisState.NAME)]
	[Controller (LiveProjectAnalysisState.NAME)]
	[Controller (LightLiveProjectState.NAME)]
	public class LMEventsController : EventsController
	{
		LMProjectAnalysisVM viewModel;

		public override async Task Start ()
		{
			await base.Start ();
			App.Current.EventsBroker.Subscribe<LoadTimelineEventEvent<TimelineEvent>> (HandleLoadTimelineEvent);
			App.Current.EventsBroker.Subscribe<KeyPressedEvent> (HandleKeyPressed);
			App.Current.EventsBroker.Subscribe<PlayerSubstitutionEvent> (HandlePlayerSubstitutionEvent);
			App.Current.EventsBroker.Subscribe<ShowProjectStatsEvent> (HandleShowProjectStatsEvent);
		}

		public override async Task Stop ()
		{
			App.Current.EventsBroker.Unsubscribe<LoadTimelineEventEvent<TimelineEvent>> (HandleLoadTimelineEvent);
			App.Current.EventsBroker.Unsubscribe<KeyPressedEvent> (HandleKeyPressed);
			App.Current.EventsBroker.Unsubscribe<PlayerSubstitutionEvent> (HandlePlayerSubstitutionEvent);
			App.Current.EventsBroker.Unsubscribe<ShowProjectStatsEvent> (HandleShowProjectStatsEvent);
			await base.Stop ();
		}

		public override void SetViewModel (IViewModel viewModel)
		{
			this.viewModel = (LMProjectAnalysisVM)viewModel;
			base.SetViewModel (viewModel);
		}

		// FIXME: remove this when the video capturer is ported to MVVM
		void HandleLoadTimelineEvent (LoadTimelineEventEvent<TimelineEvent> e)
		{
			VideoPlayer.LoadEvent (e.Object, e.Playing);
		}

		void HandlePlayerSubstitutionEvent (PlayerSubstitutionEvent e)
		{
			if (CheckTimelineEventsLimitation ()) {
				return;
			}
			LMTimelineEvent evt;

			try {
				evt = viewModel.Project.Model.SubsitutePlayer (e.Team, e.Player1, e.Player2, e.SubstitutionReason, e.Time);
				App.Current.EventsBroker.Publish (
					new EventCreatedEvent {
						TimelineEvent = evt
					}
				);
			} catch (SubstitutionException ex) {
				App.Current.Dialogs.ErrorMessage (ex.Message);
			}
		}

		void HandleKeyPressed (KeyPressedEvent e)
		{
			LMKeyAction action;

			try {
				action = App.Current.Config.Hotkeys.ActionsHotkeys.GetKeyByValue (e.Key);
			} catch (Exception ex) {
				/* The dictionary contains 2 equal values for different keys */
				Log.Exception (ex);
				return;
			}

			if (action == LMKeyAction.None || LoadedPlay == null) {
				return;
			}

			switch (action) {
			case LMKeyAction.EditEvent:
				bool playing = VideoPlayer.Playing;
				VideoPlayer.PauseCommand.Execute (false);

				App.Current.EventsBroker.Publish (new EditEventEvent { TimelineEvent = LoadedPlay });

				if (playing) {
					VideoPlayer.PlayCommand.Execute ();
				}
				break;
			case LMKeyAction.DeleteEvent:
				App.Current.EventsBroker.Publish (
					new EventsDeletedEvent {
						TimelineEvents = new List<TimelineEvent> { LoadedPlay }
					}
				);
				break;
			}
		}

		void HandleShowProjectStatsEvent (ShowProjectStatsEvent e)
		{
			App.Current.GUIToolkit.ShowProjectStats (e.Project);
		}

	}
}