
// This file has been generated by the GUI designer. Do not modify.
namespace LongoMatch.Gui.Component
{
	public partial class PlaysCoordinatesTagger
	{
		private global::Gtk.HBox mainbox;

		private global::Gtk.DrawingArea fieldDrawingarea;

		private global::Gtk.DrawingArea hfieldDrawingarea;

		private global::Gtk.DrawingArea goalDrawingarea;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget LongoMatch.Gui.Component.PlaysCoordinatesTagger
			global::Stetic.BinContainer.Attach (this);
			this.Name = "LongoMatch.Gui.Component.PlaysCoordinatesTagger";
			// Container child LongoMatch.Gui.Component.PlaysCoordinatesTagger.Gtk.Container+ContainerChild
			this.mainbox = new global::Gtk.HBox ();
			this.mainbox.Name = "mainbox";
			this.mainbox.Spacing = 6;
			// Container child mainbox.Gtk.Box+BoxChild
			this.fieldDrawingarea = new global::Gtk.DrawingArea ();
			this.fieldDrawingarea.Name = "fieldDrawingarea";
			this.mainbox.Add (this.fieldDrawingarea);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.mainbox [this.fieldDrawingarea]));
			w1.Position = 0;
			// Container child mainbox.Gtk.Box+BoxChild
			this.hfieldDrawingarea = new global::Gtk.DrawingArea ();
			this.hfieldDrawingarea.Name = "hfieldDrawingarea";
			this.mainbox.Add (this.hfieldDrawingarea);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.mainbox [this.hfieldDrawingarea]));
			w2.Position = 1;
			// Container child mainbox.Gtk.Box+BoxChild
			this.goalDrawingarea = new global::Gtk.DrawingArea ();
			this.goalDrawingarea.Name = "goalDrawingarea";
			this.mainbox.Add (this.goalDrawingarea);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.mainbox [this.goalDrawingarea]));
			w3.Position = 2;
			this.Add (this.mainbox);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}
