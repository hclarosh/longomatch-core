
// This file has been generated by the GUI designer. Do not modify.
namespace LongoMatch.Gui.Panel
{
	public partial class TeamsTemplatesPanel
	{
		private global::Gtk.VBox vbox3;
		private global::Gtk.EventBox headereventbox;
		private global::Gtk.HBox headerhbox;
		private global::Gtk.Image logoimage;
		private global::Gtk.Label titlelabel;
		private global::Gtk.Button backrectbutton;
		private global::Gtk.HBox hbox1;
		private global::Gtk.VBox teamsvbox;
		private global::Gtk.HButtonBox hbuttonbox4;
		private global::Gtk.Button newteamtemplatebutton;
		private global::Gtk.Button deleteteamteamplatebutton;
		private global::Gtk.Button saveteamtemplatebutton;
		private global::Gtk.Frame frame4;
		private global::Gtk.Alignment GtkAlignment7;
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		private global::Gtk.TreeView teamtemplatestreeview;
		private global::Gtk.Label GtkLabel7;
		private global::Gtk.VSeparator vseparator2;
		private global::LongoMatch.Gui.Component.TeamTemplateEditor teamtemplateeditor1;
		private global::Gtk.HButtonBox hbuttonbox3;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget LongoMatch.Gui.Panel.TeamsTemplatesPanel
			global::Stetic.BinContainer.Attach (this);
			this.Name = "LongoMatch.Gui.Panel.TeamsTemplatesPanel";
			// Container child LongoMatch.Gui.Panel.TeamsTemplatesPanel.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.headereventbox = new global::Gtk.EventBox ();
			this.headereventbox.Name = "headereventbox";
			// Container child headereventbox.Gtk.Container+ContainerChild
			this.headerhbox = new global::Gtk.HBox ();
			this.headerhbox.Name = "headerhbox";
			this.headerhbox.Spacing = 6;
			// Container child headerhbox.Gtk.Box+BoxChild
			this.logoimage = new global::Gtk.Image ();
			this.logoimage.Name = "logoimage";
			this.headerhbox.Add (this.logoimage);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.headerhbox [this.logoimage]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child headerhbox.Gtk.Box+BoxChild
			this.titlelabel = new global::Gtk.Label ();
			this.titlelabel.Name = "titlelabel";
			this.titlelabel.Xalign = 0F;
			this.titlelabel.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>TEAM TEMPLATE EDITOR</b>");
			this.titlelabel.UseMarkup = true;
			this.titlelabel.Justify = ((global::Gtk.Justification)(2));
			this.headerhbox.Add (this.titlelabel);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.headerhbox [this.titlelabel]));
			w2.Position = 1;
			w2.Expand = false;
			// Container child headerhbox.Gtk.Box+BoxChild
			this.backrectbutton = new global::Gtk.Button ();
			this.backrectbutton.WidthRequest = 80;
			this.backrectbutton.HeightRequest = 40;
			this.backrectbutton.CanFocus = true;
			this.backrectbutton.Name = "backrectbutton";
			this.backrectbutton.UseUnderline = true;
			this.backrectbutton.BorderWidth = ((uint)(10));
			// Container child backrectbutton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w3 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w4 = new global::Gtk.HBox ();
			w4.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w5 = new global::Gtk.Image ();
			w5.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "longomatch-back", global::Gtk.IconSize.Dialog);
			w4.Add (w5);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w7 = new global::Gtk.Label ();
			w4.Add (w7);
			w3.Add (w4);
			this.backrectbutton.Add (w3);
			this.headerhbox.Add (this.backrectbutton);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.headerhbox [this.backrectbutton]));
			w11.PackType = ((global::Gtk.PackType)(1));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			this.headereventbox.Add (this.headerhbox);
			this.vbox3.Add (this.headereventbox);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.headereventbox]));
			w13.Position = 0;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.teamsvbox = new global::Gtk.VBox ();
			this.teamsvbox.WidthRequest = 280;
			this.teamsvbox.Name = "teamsvbox";
			this.teamsvbox.Spacing = 6;
			// Container child teamsvbox.Gtk.Box+BoxChild
			this.hbuttonbox4 = new global::Gtk.HButtonBox ();
			this.hbuttonbox4.Name = "hbuttonbox4";
			this.hbuttonbox4.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(3));
			// Container child hbuttonbox4.Gtk.ButtonBox+ButtonBoxChild
			this.newteamtemplatebutton = new global::Gtk.Button ();
			this.newteamtemplatebutton.CanFocus = true;
			this.newteamtemplatebutton.Name = "newteamtemplatebutton";
			this.newteamtemplatebutton.UseUnderline = true;
			// Container child newteamtemplatebutton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w14 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w15 = new global::Gtk.HBox ();
			w15.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w16 = new global::Gtk.Image ();
			w16.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "longomatch-template-add", global::Gtk.IconSize.SmallToolbar);
			w15.Add (w16);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w18 = new global::Gtk.Label ();
			w15.Add (w18);
			w14.Add (w15);
			this.newteamtemplatebutton.Add (w14);
			this.hbuttonbox4.Add (this.newteamtemplatebutton);
			global::Gtk.ButtonBox.ButtonBoxChild w22 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox4 [this.newteamtemplatebutton]));
			w22.Expand = false;
			w22.Fill = false;
			// Container child hbuttonbox4.Gtk.ButtonBox+ButtonBoxChild
			this.deleteteamteamplatebutton = new global::Gtk.Button ();
			this.deleteteamteamplatebutton.CanFocus = true;
			this.deleteteamteamplatebutton.Name = "deleteteamteamplatebutton";
			this.deleteteamteamplatebutton.UseUnderline = true;
			// Container child deleteteamteamplatebutton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w23 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w24 = new global::Gtk.HBox ();
			w24.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w25 = new global::Gtk.Image ();
			w25.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "longomatch-template-delete", global::Gtk.IconSize.SmallToolbar);
			w24.Add (w25);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w27 = new global::Gtk.Label ();
			w24.Add (w27);
			w23.Add (w24);
			this.deleteteamteamplatebutton.Add (w23);
			this.hbuttonbox4.Add (this.deleteteamteamplatebutton);
			global::Gtk.ButtonBox.ButtonBoxChild w31 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox4 [this.deleteteamteamplatebutton]));
			w31.Position = 1;
			w31.Expand = false;
			w31.Fill = false;
			// Container child hbuttonbox4.Gtk.ButtonBox+ButtonBoxChild
			this.saveteamtemplatebutton = new global::Gtk.Button ();
			this.saveteamtemplatebutton.CanFocus = true;
			this.saveteamtemplatebutton.Name = "saveteamtemplatebutton";
			this.saveteamtemplatebutton.UseUnderline = true;
			// Container child saveteamtemplatebutton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w32 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w33 = new global::Gtk.HBox ();
			w33.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w34 = new global::Gtk.Image ();
			w34.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "longomatch-template-save", global::Gtk.IconSize.SmallToolbar);
			w33.Add (w34);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w36 = new global::Gtk.Label ();
			w33.Add (w36);
			w32.Add (w33);
			this.saveteamtemplatebutton.Add (w32);
			this.hbuttonbox4.Add (this.saveteamtemplatebutton);
			global::Gtk.ButtonBox.ButtonBoxChild w40 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox4 [this.saveteamtemplatebutton]));
			w40.Position = 2;
			w40.Expand = false;
			w40.Fill = false;
			this.teamsvbox.Add (this.hbuttonbox4);
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.teamsvbox [this.hbuttonbox4]));
			w41.Position = 0;
			w41.Expand = false;
			w41.Fill = false;
			// Container child teamsvbox.Gtk.Box+BoxChild
			this.frame4 = new global::Gtk.Frame ();
			this.frame4.Name = "frame4";
			this.frame4.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame4.Gtk.Container+ContainerChild
			this.GtkAlignment7 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment7.Name = "GtkAlignment7";
			this.GtkAlignment7.LeftPadding = ((uint)(12));
			// Container child GtkAlignment7.Gtk.Container+ContainerChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.teamtemplatestreeview = new global::Gtk.TreeView ();
			this.teamtemplatestreeview.CanFocus = true;
			this.teamtemplatestreeview.Name = "teamtemplatestreeview";
			this.GtkScrolledWindow1.Add (this.teamtemplatestreeview);
			this.GtkAlignment7.Add (this.GtkScrolledWindow1);
			this.frame4.Add (this.GtkAlignment7);
			this.GtkLabel7 = new global::Gtk.Label ();
			this.GtkLabel7.Name = "GtkLabel7";
			this.GtkLabel7.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Teams</b>");
			this.GtkLabel7.UseMarkup = true;
			this.frame4.LabelWidget = this.GtkLabel7;
			this.teamsvbox.Add (this.frame4);
			global::Gtk.Box.BoxChild w45 = ((global::Gtk.Box.BoxChild)(this.teamsvbox [this.frame4]));
			w45.Position = 1;
			this.hbox1.Add (this.teamsvbox);
			global::Gtk.Box.BoxChild w46 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.teamsvbox]));
			w46.Position = 0;
			w46.Expand = false;
			w46.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vseparator2 = new global::Gtk.VSeparator ();
			this.vseparator2.Name = "vseparator2";
			this.hbox1.Add (this.vseparator2);
			global::Gtk.Box.BoxChild w47 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vseparator2]));
			w47.Position = 1;
			w47.Expand = false;
			w47.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.teamtemplateeditor1 = new global::LongoMatch.Gui.Component.TeamTemplateEditor ();
			this.teamtemplateeditor1.Events = ((global::Gdk.EventMask)(256));
			this.teamtemplateeditor1.Name = "teamtemplateeditor1";
			this.hbox1.Add (this.teamtemplateeditor1);
			global::Gtk.Box.BoxChild w48 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.teamtemplateeditor1]));
			w48.Position = 2;
			this.vbox3.Add (this.hbox1);
			global::Gtk.Box.BoxChild w49 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox1]));
			w49.Position = 1;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbuttonbox3 = new global::Gtk.HButtonBox ();
			this.hbuttonbox3.Name = "hbuttonbox3";
			this.hbuttonbox3.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(3));
			this.vbox3.Add (this.hbuttonbox3);
			global::Gtk.Box.BoxChild w50 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbuttonbox3]));
			w50.Position = 2;
			w50.Expand = false;
			w50.Fill = false;
			this.Add (this.vbox3);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}
