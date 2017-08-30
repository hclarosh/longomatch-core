
// This file has been generated by the GUI designer. Do not modify.
namespace LongoMatch.Gui.Component
{
	public partial class LMLimitationWidget
	{
		private global::Gtk.EventBox backgroundBox;

		private global::Gtk.VBox vbox4;

		private global::Gtk.DrawingArea barDrawingArea;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Label countLabel;

		private global::Gtk.Button upgradeButton;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget LongoMatch.Gui.Component.LMLimitationWidget
			global::Stetic.BinContainer.Attach(this);
			this.Name = "LongoMatch.Gui.Component.LMLimitationWidget";
			// Container child LongoMatch.Gui.Component.LMLimitationWidget.Gtk.Container+ContainerChild
			this.backgroundBox = new global::Gtk.EventBox();
			this.backgroundBox.HeightRequest = 70;
			this.backgroundBox.Name = "backgroundBox";
			// Container child backgroundBox.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.HeightRequest = 70;
			this.vbox4.Name = "vbox4";
			// Container child vbox4.Gtk.Box+BoxChild
			this.barDrawingArea = new global::Gtk.DrawingArea();
			this.barDrawingArea.HeightRequest = 10;
			this.barDrawingArea.Name = "barDrawingArea";
			this.vbox4.Add(this.barDrawingArea);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.barDrawingArea]));
			w1.Position = 0;
			w1.Expand = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.HeightRequest = 60;
			this.hbox3.Name = "hbox3";
			this.hbox3.BorderWidth = ((uint)(5));
			// Container child hbox3.Gtk.Box+BoxChild
			this.countLabel = new global::Gtk.Label();
			this.countLabel.WidthRequest = 200;
			this.countLabel.HeightRequest = 40;
			this.countLabel.Name = "countLabel";
			this.countLabel.LabelProp = global::VAS.Core.Catalog.GetString("Only <b># projects</b> left in your plan!");
			this.countLabel.UseMarkup = true;
			this.countLabel.Wrap = true;
			this.countLabel.Justify = ((global::Gtk.Justification)(2));
			this.hbox3.Add(this.countLabel);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.countLabel]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.upgradeButton = new global::Gtk.Button();
			this.upgradeButton.WidthRequest = 95;
			this.upgradeButton.HeightRequest = 50;
			this.upgradeButton.Name = "upgradeButton";
			this.upgradeButton.FocusOnClick = false;
			this.upgradeButton.Label = global::VAS.Core.Catalog.GetString("UPGRADE");
			this.hbox3.Add(this.upgradeButton);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.upgradeButton]));
			w3.PackType = ((global::Gtk.PackType)(1));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			this.vbox4.Add(this.hbox3);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox3]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.backgroundBox.Add(this.vbox4);
			this.Add(this.backgroundBox);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}