
// This file has been generated by the GUI designer. Do not modify.
namespace LongoMatch.Gui.Dialog
{
	public partial class DrawingTool
	{
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.VBox vbox3;
		
		private global::Gtk.Label toolslabel;
		
		private global::Gtk.Table toolstable;
		
		private global::Gtk.RadioButton anglebutton;
		
		private global::Gtk.Image anglebuttonimage;
		
		private global::Gtk.RadioButton crossbutton;
		
		private global::Gtk.Image crossbuttonimage;
		
		private global::Gtk.RadioButton ellipsebutton;
		
		private global::Gtk.Image ellipsebuttonimage;
		
		private global::Gtk.RadioButton ellipsefilledbutton;
		
		private global::Gtk.Image ellipsefilledbuttonimage;
		
		private global::Gtk.RadioButton eraserbutton;
		
		private global::Gtk.Image eraserbuttonimage;
		
		private global::Gtk.RadioButton linebutton;
		
		private global::Gtk.Image linebuttonimage;
		
		private global::Gtk.RadioButton numberbutton;
		
		private global::Gtk.Image numberbuttonimage;
		
		private global::Gtk.RadioButton penbutton;
		
		private global::Gtk.Image penbuttonimage;
		
		private global::Gtk.RadioButton playerbutton;
		
		private global::Gtk.Image playerbuttonimage;
		
		private global::Gtk.RadioButton rectanglebutton;
		
		private global::Gtk.Image rectanglebuttonimage;
		
		private global::Gtk.RadioButton rectanglefilledbutton;
		
		private global::Gtk.Image rectanglefilledbuttonimage;
		
		private global::Gtk.RadioButton selectbutton;
		
		private global::Gtk.Image selectbuttonimage;
		
		private global::Gtk.RadioButton textbutton;
		
		private global::Gtk.Image textbuttonimage;
		
		private global::Gtk.Frame linesframe;
		
		private global::Gtk.Alignment GtkAlignment4;
		
		private global::Gtk.Table table1;
		
		private global::Gtk.ColorButton colorbutton;
		
		private global::Gtk.Label colorslabel;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.Label label4;
		
		private global::Gtk.Label label5;
		
		private global::Gtk.SpinButton linesizespinbutton;
		
		private global::Gtk.ComboBox stylecombobox;
		
		private global::Gtk.ComboBox typecombobox;
		
		private global::Gtk.Label GtkLabel4;
		
		private global::Gtk.Frame textframe;
		
		private global::Gtk.Alignment GtkAlignment13;
		
		private global::Gtk.Table table4;
		
		private global::Gtk.ColorButton backgroundcolorbutton;
		
		private global::Gtk.Label backgroundcolorslabel2;
		
		private global::Gtk.Label backgroundcolorslabel3;
		
		private global::Gtk.ColorButton textcolorbutton;
		
		private global::Gtk.Label textcolorslabel2;
		
		private global::Gtk.SpinButton textspinbutton;
		
		private global::Gtk.Label GtkLabel5;
		
		private global::Gtk.Button clearbutton;
		
		private global::Gtk.Button savetoprojectbutton;
		
		private global::Gtk.Button savebutton;
		
		private global::Gtk.DrawingArea drawingarea;
		
		private global::Gtk.Button closebutton;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget LongoMatch.Gui.Dialog.DrawingTool
			this.Name = "LongoMatch.Gui.Dialog.DrawingTool";
			this.Title = global::Mono.Unix.Catalog.GetString ("Drawing Tool");
			this.Icon = global::Stetic.IconLoader.LoadIcon (this, "longomatch", global::Gtk.IconSize.Menu);
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			this.DefaultWidth = 800;
			this.DefaultHeight = 1;
			this.Gravity = ((global::Gdk.Gravity)(5));
			this.SkipPagerHint = true;
			this.SkipTaskbarHint = true;
			// Internal child LongoMatch.Gui.Dialog.DrawingTool.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.toolslabel = new global::Gtk.Label ();
			this.toolslabel.Name = "toolslabel";
			this.toolslabel.Xalign = 0F;
			this.toolslabel.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Tools</b>");
			this.toolslabel.UseMarkup = true;
			this.vbox3.Add (this.toolslabel);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.toolslabel]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.toolstable = new global::Gtk.Table (((uint)(7)), ((uint)(2)), true);
			this.toolstable.Name = "toolstable";
			this.toolstable.RowSpacing = ((uint)(6));
			this.toolstable.ColumnSpacing = ((uint)(6));
			// Container child toolstable.Gtk.Table+TableChild
			this.anglebutton = new global::Gtk.RadioButton ("");
			this.anglebutton.TooltipMarkup = "Angle tool";
			this.anglebutton.CanFocus = true;
			this.anglebutton.Name = "anglebutton";
			this.anglebutton.DrawIndicator = false;
			this.anglebutton.UseUnderline = true;
			this.anglebutton.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.anglebutton.Remove (this.anglebutton.Child);
			// Container child anglebutton.Gtk.Container+ContainerChild
			this.anglebuttonimage = new global::Gtk.Image ();
			this.anglebuttonimage.Name = "anglebuttonimage";
			this.anglebutton.Add (this.anglebuttonimage);
			this.toolstable.Add (this.anglebutton);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.toolstable [this.anglebutton]));
			w4.TopAttach = ((uint)(6));
			w4.BottomAttach = ((uint)(7));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.crossbutton = new global::Gtk.RadioButton ("");
			this.crossbutton.TooltipMarkup = "Cross tool";
			this.crossbutton.CanFocus = true;
			this.crossbutton.Name = "crossbutton";
			this.crossbutton.DrawIndicator = false;
			this.crossbutton.UseUnderline = true;
			this.crossbutton.Group = this.anglebutton.Group;
			this.crossbutton.Remove (this.crossbutton.Child);
			// Container child crossbutton.Gtk.Container+ContainerChild
			this.crossbuttonimage = new global::Gtk.Image ();
			this.crossbuttonimage.Name = "crossbuttonimage";
			this.crossbutton.Add (this.crossbuttonimage);
			this.toolstable.Add (this.crossbutton);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.toolstable [this.crossbutton]));
			w6.TopAttach = ((uint)(2));
			w6.BottomAttach = ((uint)(3));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.ellipsebutton = new global::Gtk.RadioButton ("");
			this.ellipsebutton.TooltipMarkup = "Ellipse tool";
			this.ellipsebutton.CanFocus = true;
			this.ellipsebutton.Name = "ellipsebutton";
			this.ellipsebutton.DrawIndicator = false;
			this.ellipsebutton.UseUnderline = true;
			this.ellipsebutton.Group = this.anglebutton.Group;
			this.ellipsebutton.Remove (this.ellipsebutton.Child);
			// Container child ellipsebutton.Gtk.Container+ContainerChild
			this.ellipsebuttonimage = new global::Gtk.Image ();
			this.ellipsebuttonimage.Name = "ellipsebuttonimage";
			this.ellipsebutton.Add (this.ellipsebuttonimage);
			this.toolstable.Add (this.ellipsebutton);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.toolstable [this.ellipsebutton]));
			w8.TopAttach = ((uint)(3));
			w8.BottomAttach = ((uint)(4));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.ellipsefilledbutton = new global::Gtk.RadioButton ("");
			this.ellipsefilledbutton.TooltipMarkup = "Filled ellipse";
			this.ellipsefilledbutton.CanFocus = true;
			this.ellipsefilledbutton.Name = "ellipsefilledbutton";
			this.ellipsefilledbutton.DrawIndicator = false;
			this.ellipsefilledbutton.UseUnderline = true;
			this.ellipsefilledbutton.Group = this.anglebutton.Group;
			this.ellipsefilledbutton.Remove (this.ellipsefilledbutton.Child);
			// Container child ellipsefilledbutton.Gtk.Container+ContainerChild
			this.ellipsefilledbuttonimage = new global::Gtk.Image ();
			this.ellipsefilledbuttonimage.Name = "ellipsefilledbuttonimage";
			this.ellipsefilledbutton.Add (this.ellipsefilledbuttonimage);
			this.toolstable.Add (this.ellipsefilledbutton);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.toolstable [this.ellipsefilledbutton]));
			w10.TopAttach = ((uint)(4));
			w10.BottomAttach = ((uint)(5));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.eraserbutton = new global::Gtk.RadioButton ("");
			this.eraserbutton.TooltipMarkup = "Rubber tool";
			this.eraserbutton.CanFocus = true;
			this.eraserbutton.Name = "eraserbutton";
			this.eraserbutton.DrawIndicator = false;
			this.eraserbutton.UseUnderline = true;
			this.eraserbutton.Group = this.anglebutton.Group;
			this.eraserbutton.Remove (this.eraserbutton.Child);
			// Container child eraserbutton.Gtk.Container+ContainerChild
			this.eraserbuttonimage = new global::Gtk.Image ();
			this.eraserbuttonimage.Name = "eraserbuttonimage";
			this.eraserbutton.Add (this.eraserbuttonimage);
			this.toolstable.Add (this.eraserbutton);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.toolstable [this.eraserbutton]));
			w12.LeftAttach = ((uint)(1));
			w12.RightAttach = ((uint)(2));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.linebutton = new global::Gtk.RadioButton ("");
			this.linebutton.TooltipMarkup = "Line tool";
			this.linebutton.CanFocus = true;
			this.linebutton.Name = "linebutton";
			this.linebutton.DrawIndicator = false;
			this.linebutton.UseUnderline = true;
			this.linebutton.Group = this.anglebutton.Group;
			this.linebutton.Remove (this.linebutton.Child);
			// Container child linebutton.Gtk.Container+ContainerChild
			this.linebuttonimage = new global::Gtk.Image ();
			this.linebuttonimage.Name = "linebuttonimage";
			this.linebutton.Add (this.linebuttonimage);
			this.toolstable.Add (this.linebutton);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.toolstable [this.linebutton]));
			w14.TopAttach = ((uint)(2));
			w14.BottomAttach = ((uint)(3));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.numberbutton = new global::Gtk.RadioButton ("");
			this.numberbutton.TooltipMarkup = "Index tool";
			this.numberbutton.CanFocus = true;
			this.numberbutton.Name = "numberbutton";
			this.numberbutton.DrawIndicator = false;
			this.numberbutton.UseUnderline = true;
			this.numberbutton.Group = this.anglebutton.Group;
			this.numberbutton.Remove (this.numberbutton.Child);
			// Container child numberbutton.Gtk.Container+ContainerChild
			this.numberbuttonimage = new global::Gtk.Image ();
			this.numberbuttonimage.Name = "numberbuttonimage";
			this.numberbutton.Add (this.numberbuttonimage);
			this.toolstable.Add (this.numberbutton);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.toolstable [this.numberbutton]));
			w16.TopAttach = ((uint)(5));
			w16.BottomAttach = ((uint)(6));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(2));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.penbutton = new global::Gtk.RadioButton ("");
			this.penbutton.TooltipMarkup = "Pencil tool";
			this.penbutton.CanFocus = true;
			this.penbutton.Name = "penbutton";
			this.penbutton.DrawIndicator = false;
			this.penbutton.UseUnderline = true;
			this.penbutton.Group = this.anglebutton.Group;
			this.penbutton.Remove (this.penbutton.Child);
			// Container child penbutton.Gtk.Container+ContainerChild
			this.penbuttonimage = new global::Gtk.Image ();
			this.penbuttonimage.Name = "penbuttonimage";
			this.penbutton.Add (this.penbuttonimage);
			this.toolstable.Add (this.penbutton);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.toolstable [this.penbutton]));
			w18.TopAttach = ((uint)(1));
			w18.BottomAttach = ((uint)(2));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.playerbutton = new global::Gtk.RadioButton ("");
			this.playerbutton.TooltipMarkup = "Player tool";
			this.playerbutton.CanFocus = true;
			this.playerbutton.Name = "playerbutton";
			this.playerbutton.DrawIndicator = false;
			this.playerbutton.UseUnderline = true;
			this.playerbutton.Group = this.anglebutton.Group;
			this.playerbutton.Remove (this.playerbutton.Child);
			// Container child playerbutton.Gtk.Container+ContainerChild
			this.playerbuttonimage = new global::Gtk.Image ();
			this.playerbuttonimage.Name = "playerbuttonimage";
			this.playerbutton.Add (this.playerbuttonimage);
			this.toolstable.Add (this.playerbutton);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.toolstable [this.playerbutton]));
			w20.TopAttach = ((uint)(5));
			w20.BottomAttach = ((uint)(6));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.rectanglebutton = new global::Gtk.RadioButton ("");
			this.rectanglebutton.TooltipMarkup = "Rectangle tool";
			this.rectanglebutton.CanFocus = true;
			this.rectanglebutton.Name = "rectanglebutton";
			this.rectanglebutton.DrawIndicator = false;
			this.rectanglebutton.UseUnderline = true;
			this.rectanglebutton.Group = this.anglebutton.Group;
			this.rectanglebutton.Remove (this.rectanglebutton.Child);
			// Container child rectanglebutton.Gtk.Container+ContainerChild
			this.rectanglebuttonimage = new global::Gtk.Image ();
			this.rectanglebuttonimage.Name = "rectanglebuttonimage";
			this.rectanglebutton.Add (this.rectanglebuttonimage);
			this.toolstable.Add (this.rectanglebutton);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.toolstable [this.rectanglebutton]));
			w22.TopAttach = ((uint)(3));
			w22.BottomAttach = ((uint)(4));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.rectanglefilledbutton = new global::Gtk.RadioButton ("");
			this.rectanglefilledbutton.TooltipMarkup = "Filled rectangle tool";
			this.rectanglefilledbutton.CanFocus = true;
			this.rectanglefilledbutton.Name = "rectanglefilledbutton";
			this.rectanglefilledbutton.DrawIndicator = false;
			this.rectanglefilledbutton.UseUnderline = true;
			this.rectanglefilledbutton.Group = this.anglebutton.Group;
			this.rectanglefilledbutton.Remove (this.rectanglefilledbutton.Child);
			// Container child rectanglefilledbutton.Gtk.Container+ContainerChild
			this.rectanglefilledbuttonimage = new global::Gtk.Image ();
			this.rectanglefilledbuttonimage.Name = "rectanglefilledbuttonimage";
			this.rectanglefilledbutton.Add (this.rectanglefilledbuttonimage);
			this.toolstable.Add (this.rectanglefilledbutton);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.toolstable [this.rectanglefilledbutton]));
			w24.TopAttach = ((uint)(4));
			w24.BottomAttach = ((uint)(5));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.selectbutton = new global::Gtk.RadioButton ("");
			this.selectbutton.TooltipMarkup = "Selection tool";
			this.selectbutton.CanFocus = true;
			this.selectbutton.Name = "selectbutton";
			this.selectbutton.DrawIndicator = false;
			this.selectbutton.UseUnderline = true;
			this.selectbutton.Group = this.anglebutton.Group;
			this.selectbutton.Remove (this.selectbutton.Child);
			// Container child selectbutton.Gtk.Container+ContainerChild
			this.selectbuttonimage = new global::Gtk.Image ();
			this.selectbuttonimage.Name = "selectbuttonimage";
			this.selectbutton.Add (this.selectbuttonimage);
			this.toolstable.Add (this.selectbutton);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.toolstable [this.selectbutton]));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.textbutton = new global::Gtk.RadioButton ("");
			this.textbutton.TooltipMarkup = "Text tool";
			this.textbutton.CanFocus = true;
			this.textbutton.Name = "textbutton";
			this.textbutton.DrawIndicator = false;
			this.textbutton.UseUnderline = true;
			this.textbutton.Group = this.anglebutton.Group;
			this.textbutton.Remove (this.textbutton.Child);
			// Container child textbutton.Gtk.Container+ContainerChild
			this.textbuttonimage = new global::Gtk.Image ();
			this.textbuttonimage.Name = "textbuttonimage";
			this.textbutton.Add (this.textbuttonimage);
			this.toolstable.Add (this.textbutton);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.toolstable [this.textbutton]));
			w28.TopAttach = ((uint)(1));
			w28.BottomAttach = ((uint)(2));
			w28.LeftAttach = ((uint)(1));
			w28.RightAttach = ((uint)(2));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox3.Add (this.toolstable);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.toolstable]));
			w29.Position = 1;
			w29.Expand = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.linesframe = new global::Gtk.Frame ();
			this.linesframe.Name = "linesframe";
			this.linesframe.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child linesframe.Gtk.Container+ContainerChild
			this.GtkAlignment4 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment4.Name = "GtkAlignment4";
			this.GtkAlignment4.LeftPadding = ((uint)(12));
			// Container child GtkAlignment4.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table (((uint)(4)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.colorbutton = new global::Gtk.ColorButton ();
			this.colorbutton.CanFocus = true;
			this.colorbutton.Events = ((global::Gdk.EventMask)(784));
			this.colorbutton.Name = "colorbutton";
			this.table1.Add (this.colorbutton);
			global::Gtk.Table.TableChild w30 = ((global::Gtk.Table.TableChild)(this.table1 [this.colorbutton]));
			w30.LeftAttach = ((uint)(1));
			w30.RightAttach = ((uint)(2));
			w30.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.colorslabel = new global::Gtk.Label ();
			this.colorslabel.Name = "colorslabel";
			this.colorslabel.Xalign = 0F;
			this.colorslabel.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Color</b>");
			this.colorslabel.UseMarkup = true;
			this.table1.Add (this.colorslabel);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.table1 [this.colorslabel]));
			w31.XOptions = ((global::Gtk.AttachOptions)(4));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 0F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Size</b>");
			this.label3.UseMarkup = true;
			this.table1.Add (this.label3);
			global::Gtk.Table.TableChild w32 = ((global::Gtk.Table.TableChild)(this.table1 [this.label3]));
			w32.TopAttach = ((uint)(1));
			w32.BottomAttach = ((uint)(2));
			w32.XOptions = ((global::Gtk.AttachOptions)(4));
			w32.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 0F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Style</b>");
			this.label4.UseMarkup = true;
			this.table1.Add (this.label4);
			global::Gtk.Table.TableChild w33 = ((global::Gtk.Table.TableChild)(this.table1 [this.label4]));
			w33.TopAttach = ((uint)(2));
			w33.BottomAttach = ((uint)(3));
			w33.XOptions = ((global::Gtk.AttachOptions)(4));
			w33.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 0F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Type</b>");
			this.label5.UseMarkup = true;
			this.table1.Add (this.label5);
			global::Gtk.Table.TableChild w34 = ((global::Gtk.Table.TableChild)(this.table1 [this.label5]));
			w34.TopAttach = ((uint)(3));
			w34.BottomAttach = ((uint)(4));
			w34.XOptions = ((global::Gtk.AttachOptions)(4));
			w34.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.linesizespinbutton = new global::Gtk.SpinButton (2, 20, 1);
			this.linesizespinbutton.CanFocus = true;
			this.linesizespinbutton.Name = "linesizespinbutton";
			this.linesizespinbutton.Adjustment.PageIncrement = 10;
			this.linesizespinbutton.ClimbRate = 1;
			this.linesizespinbutton.Numeric = true;
			this.linesizespinbutton.Value = 4;
			this.table1.Add (this.linesizespinbutton);
			global::Gtk.Table.TableChild w35 = ((global::Gtk.Table.TableChild)(this.table1 [this.linesizespinbutton]));
			w35.TopAttach = ((uint)(1));
			w35.BottomAttach = ((uint)(2));
			w35.LeftAttach = ((uint)(1));
			w35.RightAttach = ((uint)(2));
			w35.XOptions = ((global::Gtk.AttachOptions)(4));
			w35.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.stylecombobox = global::Gtk.ComboBox.NewText ();
			this.stylecombobox.TooltipMarkup = "Change the line style";
			this.stylecombobox.Name = "stylecombobox";
			this.table1.Add (this.stylecombobox);
			global::Gtk.Table.TableChild w36 = ((global::Gtk.Table.TableChild)(this.table1 [this.stylecombobox]));
			w36.TopAttach = ((uint)(2));
			w36.BottomAttach = ((uint)(3));
			w36.LeftAttach = ((uint)(1));
			w36.RightAttach = ((uint)(2));
			w36.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.typecombobox = global::Gtk.ComboBox.NewText ();
			this.typecombobox.TooltipMarkup = "Change the line style";
			this.typecombobox.Name = "typecombobox";
			this.table1.Add (this.typecombobox);
			global::Gtk.Table.TableChild w37 = ((global::Gtk.Table.TableChild)(this.table1 [this.typecombobox]));
			w37.TopAttach = ((uint)(3));
			w37.BottomAttach = ((uint)(4));
			w37.LeftAttach = ((uint)(1));
			w37.RightAttach = ((uint)(2));
			w37.YOptions = ((global::Gtk.AttachOptions)(4));
			this.GtkAlignment4.Add (this.table1);
			this.linesframe.Add (this.GtkAlignment4);
			this.GtkLabel4 = new global::Gtk.Label ();
			this.GtkLabel4.Name = "GtkLabel4";
			this.GtkLabel4.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Lines</b>");
			this.GtkLabel4.UseMarkup = true;
			this.linesframe.LabelWidget = this.GtkLabel4;
			this.vbox3.Add (this.linesframe);
			global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.linesframe]));
			w40.Position = 2;
			w40.Expand = false;
			w40.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.textframe = new global::Gtk.Frame ();
			this.textframe.Name = "textframe";
			this.textframe.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child textframe.Gtk.Container+ContainerChild
			this.GtkAlignment13 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment13.Name = "GtkAlignment13";
			this.GtkAlignment13.LeftPadding = ((uint)(12));
			// Container child GtkAlignment13.Gtk.Container+ContainerChild
			this.table4 = new global::Gtk.Table (((uint)(3)), ((uint)(2)), false);
			this.table4.Name = "table4";
			this.table4.RowSpacing = ((uint)(6));
			this.table4.ColumnSpacing = ((uint)(6));
			// Container child table4.Gtk.Table+TableChild
			this.backgroundcolorbutton = new global::Gtk.ColorButton ();
			this.backgroundcolorbutton.CanFocus = true;
			this.backgroundcolorbutton.Events = ((global::Gdk.EventMask)(784));
			this.backgroundcolorbutton.Name = "backgroundcolorbutton";
			this.table4.Add (this.backgroundcolorbutton);
			global::Gtk.Table.TableChild w41 = ((global::Gtk.Table.TableChild)(this.table4 [this.backgroundcolorbutton]));
			w41.TopAttach = ((uint)(1));
			w41.BottomAttach = ((uint)(2));
			w41.LeftAttach = ((uint)(1));
			w41.RightAttach = ((uint)(2));
			w41.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table4.Gtk.Table+TableChild
			this.backgroundcolorslabel2 = new global::Gtk.Label ();
			this.backgroundcolorslabel2.Name = "backgroundcolorslabel2";
			this.backgroundcolorslabel2.Xalign = 0F;
			this.backgroundcolorslabel2.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Background</b>");
			this.backgroundcolorslabel2.UseMarkup = true;
			this.table4.Add (this.backgroundcolorslabel2);
			global::Gtk.Table.TableChild w42 = ((global::Gtk.Table.TableChild)(this.table4 [this.backgroundcolorslabel2]));
			w42.TopAttach = ((uint)(1));
			w42.BottomAttach = ((uint)(2));
			w42.XOptions = ((global::Gtk.AttachOptions)(4));
			w42.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table4.Gtk.Table+TableChild
			this.backgroundcolorslabel3 = new global::Gtk.Label ();
			this.backgroundcolorslabel3.Name = "backgroundcolorslabel3";
			this.backgroundcolorslabel3.Xalign = 0F;
			this.backgroundcolorslabel3.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Size</b>");
			this.backgroundcolorslabel3.UseMarkup = true;
			this.table4.Add (this.backgroundcolorslabel3);
			global::Gtk.Table.TableChild w43 = ((global::Gtk.Table.TableChild)(this.table4 [this.backgroundcolorslabel3]));
			w43.TopAttach = ((uint)(2));
			w43.BottomAttach = ((uint)(3));
			w43.XOptions = ((global::Gtk.AttachOptions)(4));
			w43.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table4.Gtk.Table+TableChild
			this.textcolorbutton = new global::Gtk.ColorButton ();
			this.textcolorbutton.CanFocus = true;
			this.textcolorbutton.Events = ((global::Gdk.EventMask)(784));
			this.textcolorbutton.Name = "textcolorbutton";
			this.table4.Add (this.textcolorbutton);
			global::Gtk.Table.TableChild w44 = ((global::Gtk.Table.TableChild)(this.table4 [this.textcolorbutton]));
			w44.LeftAttach = ((uint)(1));
			w44.RightAttach = ((uint)(2));
			w44.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table4.Gtk.Table+TableChild
			this.textcolorslabel2 = new global::Gtk.Label ();
			this.textcolorslabel2.Name = "textcolorslabel2";
			this.textcolorslabel2.Xalign = 0F;
			this.textcolorslabel2.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Color</b>");
			this.textcolorslabel2.UseMarkup = true;
			this.table4.Add (this.textcolorslabel2);
			global::Gtk.Table.TableChild w45 = ((global::Gtk.Table.TableChild)(this.table4 [this.textcolorslabel2]));
			w45.XOptions = ((global::Gtk.AttachOptions)(4));
			w45.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table4.Gtk.Table+TableChild
			this.textspinbutton = new global::Gtk.SpinButton (6, 100, 1);
			this.textspinbutton.CanFocus = true;
			this.textspinbutton.Name = "textspinbutton";
			this.textspinbutton.Adjustment.PageIncrement = 10;
			this.textspinbutton.ClimbRate = 1;
			this.textspinbutton.Numeric = true;
			this.textspinbutton.Value = 12;
			this.table4.Add (this.textspinbutton);
			global::Gtk.Table.TableChild w46 = ((global::Gtk.Table.TableChild)(this.table4 [this.textspinbutton]));
			w46.TopAttach = ((uint)(2));
			w46.BottomAttach = ((uint)(3));
			w46.LeftAttach = ((uint)(1));
			w46.RightAttach = ((uint)(2));
			w46.YOptions = ((global::Gtk.AttachOptions)(4));
			this.GtkAlignment13.Add (this.table4);
			this.textframe.Add (this.GtkAlignment13);
			this.GtkLabel5 = new global::Gtk.Label ();
			this.GtkLabel5.Name = "GtkLabel5";
			this.GtkLabel5.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Text</b>");
			this.GtkLabel5.UseMarkup = true;
			this.textframe.LabelWidget = this.GtkLabel5;
			this.vbox3.Add (this.textframe);
			global::Gtk.Box.BoxChild w49 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.textframe]));
			w49.Position = 3;
			w49.Expand = false;
			w49.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.clearbutton = new global::Gtk.Button ();
			this.clearbutton.TooltipMarkup = "Clear all drawings";
			this.clearbutton.CanFocus = true;
			this.clearbutton.Name = "clearbutton";
			this.clearbutton.UseUnderline = true;
			global::Gtk.Image w50 = new global::Gtk.Image ();
			w50.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-clear", global::Gtk.IconSize.LargeToolbar);
			this.clearbutton.Image = w50;
			this.vbox3.Add (this.clearbutton);
			global::Gtk.Box.BoxChild w51 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.clearbutton]));
			w51.PackType = ((global::Gtk.PackType)(1));
			w51.Position = 4;
			w51.Expand = false;
			w51.Fill = false;
			this.vbox2.Add (this.vbox3);
			global::Gtk.Box.BoxChild w52 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.vbox3]));
			w52.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.savetoprojectbutton = new global::Gtk.Button ();
			this.savetoprojectbutton.CanFocus = true;
			this.savetoprojectbutton.Name = "savetoprojectbutton";
			this.savetoprojectbutton.UseUnderline = true;
			this.savetoprojectbutton.Label = global::Mono.Unix.Catalog.GetString ("Save to Project");
			global::Gtk.Image w53 = new global::Gtk.Image ();
			w53.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-save", global::Gtk.IconSize.Menu);
			this.savetoprojectbutton.Image = w53;
			this.vbox2.Add (this.savetoprojectbutton);
			global::Gtk.Box.BoxChild w54 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.savetoprojectbutton]));
			w54.PackType = ((global::Gtk.PackType)(1));
			w54.Position = 1;
			w54.Expand = false;
			w54.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.savebutton = new global::Gtk.Button ();
			this.savebutton.CanFocus = true;
			this.savebutton.Name = "savebutton";
			this.savebutton.UseUnderline = true;
			this.savebutton.Label = global::Mono.Unix.Catalog.GetString ("Save to File");
			global::Gtk.Image w55 = new global::Gtk.Image ();
			w55.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-save", global::Gtk.IconSize.Menu);
			this.savebutton.Image = w55;
			this.vbox2.Add (this.savebutton);
			global::Gtk.Box.BoxChild w56 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.savebutton]));
			w56.PackType = ((global::Gtk.PackType)(1));
			w56.Position = 2;
			w56.Expand = false;
			w56.Fill = false;
			this.hbox1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w57 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox2]));
			w57.Position = 0;
			w57.Expand = false;
			w57.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.drawingarea = new global::Gtk.DrawingArea ();
			this.drawingarea.Name = "drawingarea";
			this.hbox1.Add (this.drawingarea);
			global::Gtk.Box.BoxChild w58 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.drawingarea]));
			w58.Position = 1;
			w1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w59 = ((global::Gtk.Box.BoxChild)(w1 [this.hbox1]));
			w59.Position = 0;
			// Internal child LongoMatch.Gui.Dialog.DrawingTool.ActionArea
			global::Gtk.HButtonBox w60 = this.ActionArea;
			w60.Name = "dialog1_ActionArea";
			w60.Spacing = 6;
			w60.BorderWidth = ((uint)(5));
			w60.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.closebutton = new global::Gtk.Button ();
			this.closebutton.CanFocus = true;
			this.closebutton.Name = "closebutton";
			this.closebutton.UseUnderline = true;
			this.closebutton.Label = global::Mono.Unix.Catalog.GetString ("Close");
			global::Gtk.Image w61 = new global::Gtk.Image ();
			w61.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-close", global::Gtk.IconSize.Menu);
			this.closebutton.Image = w61;
			this.AddActionWidget (this.closebutton, 0);
			global::Gtk.ButtonBox.ButtonBoxChild w62 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w60 [this.closebutton]));
			w62.Expand = false;
			w62.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.anglebutton.Hide ();
			this.savetoprojectbutton.Hide ();
			this.closebutton.Hide ();
			this.Show ();
		}
	}
}
