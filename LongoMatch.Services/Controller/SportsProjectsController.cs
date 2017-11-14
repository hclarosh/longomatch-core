﻿//
//  Copyright (C) 2016 Fluendo S.A.
//
//

using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using LongoMatch.Core.Events;
using LongoMatch.Core.Store;
using LongoMatch.Core.ViewModel;
using LongoMatch.Services.State;
using LongoMatch.Services.ViewModel;
using VAS.Core.Filters;
using VAS.Core.Events;
using VAS.Core.MVVMC;
using VAS.Services.Controller;
using VAS.Services.State;

namespace LongoMatch.Services.Controller
{

	/// <summary>
	/// Controller for sports projects.
	/// </summary>
	[ControllerAttribute (ProjectsManagerState.NAME)]
	public class SportsProjectsController : ProjectsController<LMProject, LMProjectVM>
	{
		string textFilter = string.Empty;

		public new SportsProjectsManagerVM ViewModel {
			get {
				return (SportsProjectsManagerVM)base.ViewModel;
			}
			set {
				base.ViewModel = value;
			}
		}

		public override async Task Start ()
		{
			await base.Start ();
			App.Current.EventsBroker.SubscribeAsync<ResyncEvent> (HandleResync);
			App.Current.EventsBroker.Subscribe<OpenEvent<LMProject>> (HandleOpen);
			App.Current.EventsBroker.Subscribe<SearchEvent<LMProject>> (model => HandleSearch (model.TextFilter));
		}

		public override async Task Stop ()
		{
			await base.Stop ();
			App.Current.EventsBroker.UnsubscribeAsync<ResyncEvent> (HandleResync);
			App.Current.EventsBroker.Unsubscribe<OpenEvent<LMProject>> (HandleOpen);
		}

		protected override void ConnectEvents ()
		{
			base.ConnectEvents ();
		}

		protected override void DisconnectEvents ()
		{
			base.DisconnectEvents ();
		}

		protected override void HandleSelectionChanged (object sender, NotifyCollectionChangedEventArgs e)
		{
			base.HandleSelectionChanged (sender, e);
			ViewModel.ResyncCommand.EmitCanExecuteChanged ();
		}

		async Task HandleResync (ResyncEvent ev)
		{
			if (!ViewModel.LoadedProject.FileSet.Model.CheckFiles ()) {
				// Show message in order to load video.
				if (!App.Current.GUIToolkit.SelectMediaFiles (ViewModel.LoadedProject.FileSet.Model)) {
					return;
				}
			}

			dynamic data = new System.Dynamic.ExpandoObject ();

			ViewModel.LoadedProject.Model.Load ();
			data.ProjectVM = ViewModel.LoadedProject;
			data.SynchronizeEventsWithPeriods = false;
			await App.Current.StateController.MoveTo (CameraSynchronizationEditorState.NAME, data);
			ViewModel.SaveCommand.EmitCanExecuteChanged ();
		}

		void HandleOpen (OpenEvent<LMProject> arg)
		{
			if (ViewModel.LoadedProject != null) {
				// We get the selection instead of LoadedProject because it can be modified without saving.
				// Also we don't use the selected VM directly because it's disposed on unload
				LMProjectVM selectedVM = new LMProjectVM { Model = ViewModel.Selection.First ().Model };
				LMStateHelper.OpenProject (selectedVM);
			}
		}

		void HandleSearch (string text)
		{
			foreach (var lmProjectVM in ViewModel.ViewModels) {
				//FIXME: Move Search to Controller
				lmProjectVM.Visible = lmProjectVM.Model.Description.Search (text);
			}
			ViewModel.VisibleViewModels = new VisibleRangeObservableProxy<LMProjectVM> (ViewModel.ViewModels);
			textFilter = text;
			ViewModel.VisibleViewModels.ApplyPropertyChanges ();
		}
	}
}

