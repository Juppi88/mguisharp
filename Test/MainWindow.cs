using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MGUI;
using MGUI.Math;

namespace TestApp
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			// Resizing is slightly dodgy, so we're doing this
			this.FormBorderStyle = FormBorderStyle.Fixed3D;

			InitializeComponent();

			string skin = null;

			if ( File.Exists( "mguiskin.png" ) )
				skin = "mguiskin.png";

			MyllyGUI.Initialize( this.Handle, skin );
		}

		~MainWindow()
		{
			MyllyGUI.Shutdown();
			Renderer.Shutdown();
		}

		private void MainWindow_Resize( object sender, System.EventArgs e )
		{
			MyllyGUI.Resize( (ushort)Width, (ushort)Height );
			ResizeWindow();
		}

		protected override void OnPaint( PaintEventArgs e )
		{
			base.OnPaint( e );
			MyllyGUI.Redraw();
		}

		private void ResizeWindow()
		{
			short w = (short)this.Width, h = (short)this.Height;

			button.AbsolutePos = new VectorScreen( (short)( w - 71 ), (short)( h - 60 ) );
			button.AbsoluteSize = new VectorScreen( 50, 22 );

			editbox.AbsolutePos = new VectorScreen( 12, (short)( h - 60 ) );
			editbox.AbsoluteSize = new VectorScreen( (short)( w - 92 ), 22 );

			memobox.AbsolutePos = new VectorScreen( 12, 10 );
			memobox.AbsoluteSize = new VectorScreen( (short)( w - 30 ), (short)( h - 78 ) );
		}

		private void Button_Submit( object sender, CursorEventArgs args )
		{
			if ( editbox.TextLength == 0 ) return;

			memobox.AddLine( "] " + editbox.Text );

			editbox.Text = "";
			editbox.Focus = true;
		}

		private void Editbox_Return( object sender, EventArgs args )
		{
			if ( editbox.TextLength == 0 ) return;
			
			memobox.AddLine( "] " + editbox.Text );

			editbox.Text = "";
			editbox.Focus = true;
		}

		private void MainWindow_Load( object sender, EventArgs e )
		{
			canvas = new MGUI.Canvas( Element.Null );
			canvas.AddFlags( ELEMFLAG.BACKGROUND );
			canvas.Colour = colWindow;

			button = new MGUI.Button( canvas );
			button.Colour = colWindow;
			button.TextColour = colText;
			button.Text = "Submit";
			button.SetFont( "Verdana", 11, FONTFLAG.NONE );
			button.OnMouseRelease += new CursorEventHandler( Button_Submit );

			editbox = new MGUI.Editbox( canvas );
			editbox.Colour = colTextBG;
			editbox.TextColour = colText;
			editbox.FontName = "Lucida Console";
			editbox.OnInputTextReturn += new EventHandler( Editbox_Return );

			memobox = new MGUI.Memobox( canvas );
			memobox.Colour = colTextBG;
			memobox.TextColour = colText;
			memobox.SetFont( "Lucida Console", 10, 0 );
			memobox.AddFlags( ELEMFLAG.MEMOBOX_TOPBOTTOM | ELEMFLAG.TEXT_TAGS );
			memobox.SetPadding( 10, 4, 10, 10 );

			ResizeWindow(); 

			memobox.AddLine( "MGUI Console Test loaded." );
			memobox.AddColouredLine( "Hello from [#00ffff][#uline]C#[#e]!", new Colour( 255, 0, 255 ) );
		}

		private MGUI.Canvas canvas;
		private MGUI.Button button;
		private MGUI.Editbox editbox;
		private MGUI.Memobox memobox;

		private static MGUI.Math.Colour colWindow = new MGUI.Math.Colour( 75, 75, 75 );
		private static MGUI.Math.Colour colText = new MGUI.Math.Colour( 255, 255, 255 );
		private static MGUI.Math.Colour colTextBG = new MGUI.Math.Colour( 20, 20, 20 );
	}
}
