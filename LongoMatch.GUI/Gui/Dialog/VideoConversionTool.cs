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
using System.Collections.Generic;
using System.Linq;
using Gtk;
using LongoMatch.Core.Common;
using LongoMatch.Gui.Component;
using VAS.Core;
using VAS.Core.Common;
using VAS.Core.MVVMC;
using VAS.Core.Resources.Styles;
using VAS.Core.Store;
using VAS.Core.ViewModel;
using VAS.UI.Helpers;
using Constants = LongoMatch.Core.Common.Constants;
using Misc = VAS.UI.Helpers.Misc;

namespace LongoMatch.Gui.Dialog
{
	public partial class VideoConversionTool : Gtk.Dialog
	{
		ListStore stdStore;
		ListStore bitStore;
		uint maxHeight;
		VideoStandard selectedVideoStandard;
		VideoStandard [] supportedVideoStandards;
		LimitationCommand conversionCommand;

		public VideoConversionTool ()
		{
			this.Build ();
			buttonOk.Sensitive = false;
			Files = new List<MediaFile> ();
			supportedVideoStandards = VideoStandards.Transcode;
			maxHeight = supportedVideoStandards [0].Height;
			mediafilechooser1.FileChooserMode = FileChooserMode.File;
			mediafilechooser1.ChangedEvent += HandleFileChanges;
			mediafilechooser1.ProposedFileName = String.Format ("{0}-Video-{1}.mp4", Constants.SOFTWARE_NAME,
				DateTime.Now.ToShortDateString ().Replace ('/', '-'));
			FillStandards ();
			FillBitrates ();
			addbutton1.Clicked += OnAddbuttonClicked;
			convertimage.Image = App.Current.ResourcesLocator.LoadIcon ("lm-video-converter-big", 64);
			addimage.Image = App.Current.ResourcesLocator.LoadIcon ("vas-add", Sizes.ButtonNormalSize);
			eventbox1.ModifyBg (StateType.Normal, Misc.ToGdkColor (App.Current.Style.ThemeBase));
			addbutton1.CanFocus = false;
			scrolledwindow1.Visible = false;
			conversionCommand = new LimitationCommand (LongoMatchFeature.VideoConverter.ToString (), ExecuteConversion);
			// FIXME: port to viewmodel this view and do the proper bindings
			buttonOk.BindManually (conversionCommand);
		}

		public List<MediaFile> Files {
			get;
			set;
		}

		public EncodingSettings EncodingSettings {
			get;
			set;
		}

		void CheckStatus ()
		{
			scrolledwindow1.Visible = Files.Count != 0;
			buttonOk.Sensitive = mediafilechooser1.CurrentPath != null && Files.Count != 0;
		}

		void FillStandards ()
		{
			int index = 0, active = 0;
			VideoStandard min_std = null;

			stdStore = new ListStore (typeof (string), typeof (VideoStandard));
			foreach (VideoStandard std in supportedVideoStandards) {
				if (std.Height <= maxHeight) {
					stdStore.AppendValues (std.Name, std);
					if (std == selectedVideoStandard) {
						active = index;
					}
					index++;
				}
				if (min_std == null || std.Height < min_std.Height) {
					min_std = std;
				}
			}
			if (index == 0 && min_std != null) {
				// No Video Standard matches the max Height of our video files, add the smallest
				// supported standard to the list.
				stdStore.AppendValues (min_std.Name, min_std);
			}
			sizecombobox.Model = stdStore;
			sizecombobox.Active = active;
		}

		void FillBitrates ()
		{
			bitStore = new ListStore (typeof (string), typeof (EncodingQuality));
			foreach (EncodingQuality qual in EncodingQualities.Transcode) {
				bitStore.AppendValues (qual.Name, qual);
			}
			bitratecombobox.Model = bitStore;
			bitratecombobox.Active = 1;
		}

		void AppendFile (MediaFile file)
		{
			HBox box;
			Button delButton;
			Gtk.Image delImage;
			VideoFileInfo fileinfo;

			if (file == null)
				return;
			Files.Add (file);
			box = new HBox ();
			delButton = new Button ();
			delButton.Relief = ReliefStyle.None;
			delButton.CanFocus = false;
			delImage = new Gtk.Image ("gtk-remove", IconSize.Button);
			delButton.Add (delImage);
			delButton.Clicked += (object sender, EventArgs e) => {
				filesbox.Remove (box);
				Files.Remove (file);
				CheckStatus ();
			};
			fileinfo = new VideoFileInfo ();
			// FIXME: Migrate this to MVVM correctly
			fileinfo.SetMediaFile (new MediaFileVM { Model = file });
			box.PackStart (fileinfo, true, true, 0);
			box.PackStart (delButton, false, false, 0);
			box.ShowAll ();
			filesbox.PackStart (box, false, true, 0);
		}

		protected void OnAddbuttonClicked (object sender, System.EventArgs e)
		{
			TreeIter iter;

			var msg = Catalog.GetString ("Add file");
			List<string> paths = FileChooserHelper.OpenFiles (this, msg, null, null, null, null);
			foreach (string path in paths) {
				MediaFile mediaFile = Misc.DiscoverFile (path, this);
				if (mediaFile != null) {
					AppendFile (mediaFile);
				}
			}
			CheckStatus ();

			if (Files.Count > 0) {
				maxHeight = Files.Max (f => f.VideoHeight);
				sizecombobox.GetActiveIter (out iter);
				selectedVideoStandard = stdStore.GetValue (iter, 1) as VideoStandard;
				FillStandards ();
			}
		}

		void HandleFileChanges (object sender, EventArgs e)
		{
			CheckStatus ();
		}

		void ExecuteConversion ()
		{
			EncodingSettings encSettings;
			EncodingQuality qual;
			TreeIter iter;
			VideoStandard std;
			uint fps_n, fps_d;

			sizecombobox.GetActiveIter (out iter);
			std = (VideoStandard)stdStore.GetValue (iter, 1);

			bitratecombobox.GetActiveIter (out iter);
			qual = bitStore.GetValue (iter, 1) as EncodingQuality;

			var rates = new HashSet<uint> (Files.Select (f => (uint)f.Fps));
			if (rates.Count == 1) {
				fps_n = rates.First ();
				fps_d = 1;
			} else {
				fps_n = App.Current.Config.FPS_N;
				fps_d = App.Current.Config.FPS_D;
			}

			if (fps_n == 50) {
				fps_n = 25;
			} else if (fps_n == 60) {
				fps_n = 30;
			}
			encSettings = new EncodingSettings (std, EncodingProfiles.MP4, qual, fps_n, fps_d,
				mediafilechooser1.CurrentPath, true, false, 0, null);

			EncodingSettings = encSettings;

			ConversionJob job = new ConversionJob (Files, EncodingSettings);
			App.Current.JobsManager.Add (job);

			Respond (ResponseType.Ok);
		}
	}
}
