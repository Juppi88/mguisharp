using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using MGUI;
using MGUI.Math;

// This code is deprecated, it might no longer fully implement the renderer API.
// It is recommended to use the native hardware accelerated renderer implemented in
// mgui.dll (as this example app does).

namespace TestApp
{
	// Take a look at IRenderer in IRenderer.cs for the renderer function 'prototypes'.
	static class Renderer
	{
		// --------------------------------------------------
		// Initialization methods
		// --------------------------------------------------

		public static IRenderer Initialize( Form window, int width, int height )
		{
			handle.begin = Begin;
			handle.end = End;
			handle.resize = Resize;
			handle.set_draw_mode = SetDrawMode;
			handle.set_draw_colour = SetDrawColour;
			handle.set_draw_depth = SetDrawDepth;
			handle.set_draw_transform = SetDrawTransform;
			handle.reset_draw_transform = ResetDrawTransform;
			handle.start_clip = StartClip;
			handle.end_clip = EndClip;
			handle.draw_rect = DrawRect;
			handle.draw_triangle = DrawTriangle;
			handle.draw_pixel = DrawPixel;
			handle.load_texture = LoadTexture;
			handle.destroy_texture = DestroyTexture;
			handle.draw_textured_rect = DrawTexturedRect;
			handle.load_font = LoadFont;
			handle.destroy_font = DestroyFont;
			handle.draw_text = DrawText;
			handle.measure_text = MeasureText;
			handle.screen_pos_to_world = ScreenPosToWorld;
			handle.world_pos_to_screen = WorldPosToScreen;

			// Prepare graphics
			Graphics gc = window.CreateGraphics();

			bitmap = new Bitmap( width, height, gc );
			graphics = Graphics.FromImage( bitmap );
			brush = new SolidBrush( Color.White );
			drawWindow = window;

			gc.Dispose();

			// Create storage for allocated objects (fonts, textures)
			fontIndex = 0;
			fonts = new Dictionary<uint, Font>();
			//textures = new List<IntPtr>();

			return handle;
		}

		public static void Shutdown()
		{
			graphics.Dispose();
			fonts.Clear();
		}

		// --------------------------------------------------
		// Renderer implementation methods
		// --------------------------------------------------

		private static void Begin()
		{
		}

		private static void End()
		{
			Graphics gc = drawWindow.CreateGraphics();

			gc.DrawImage( bitmap, 0, 0 );
			gc.Dispose();

			graphics.Clear( Color.White );
		}

		private static void Resize( uint width, uint height )
		{
		}

		private static DRAWMODE SetDrawMode( DRAWMODE mode )
		{
			return DRAWMODE.DRAWING_2D;
		}

		private static void SetDrawColour( ref Colour col )
		{
			drawColour = Color.FromArgb( col.a, col.r, col.g, col.b );
		}

		private static void SetDrawDepth( float depth )
		{
		}

		private static void SetDrawTransform( ref Matrix4 mat )
		{
		}

		private static void ResetDrawTransform()
		{
		}

		private static void StartClip( int x, int y, uint w, uint h )
		{
		}

		private static void EndClip()
		{
		}

		private static void DrawRect( int x, int y, uint w, uint h )
		{
			brush.Color = drawColour;
			graphics.FillRectangle( brush, (int)x, (int)y, (int)w, (int)h );
		}

		private static void DrawTriangle( int x1, int y1, int x2, int y2, int x3, int y3 )
		{
		}

		private static void DrawPixel( int x, int y )
		{
		}

		private static IntPtr LoadTexture( string path, out uint width, out uint height )
		{
			width = 0;
			height = 0;

			return IntPtr.Zero;
		}

		private static void DestroyTexture( IntPtr texture )
		{
		}

		private static void DrawTexturedRect( IntPtr texture, int x, int y, uint w, uint h, float[] uv )
		{
		}

		private static UInt32 LoadFont( string font, uint size, uint flags, uint charset, uint firstc, uint lastc )
		{
			Font gdiFont;
			FontStyle style = 0;

			if ( ( flags & (uint)FONTFLAG.BOLD ) != 0 )		style |= FontStyle.Bold;
			if ( ( flags & (uint)FONTFLAG.ITALIC ) != 0 )	style |= FontStyle.Italic;
			if ( ( flags & (uint)FONTFLAG.ULINE ) != 0 )	style |= FontStyle.Underline;
			if ( ( flags & (uint)FONTFLAG.STRIKE ) != 0 )	style |= FontStyle.Strikeout;

			gdiFont = new Font( font, (float)size, style, GraphicsUnit.Pixel, (byte)charset );
			fonts.Add( ++fontIndex, gdiFont );

			return fontIndex;
		}

		private static void DestroyFont( UInt32 font )
		{
			if ( !fonts.ContainsKey( font ) ) return;
			fonts.Remove( font );
		}

		private static void DrawText( UInt32 font, string text, int x, int y, uint flags, IntPtr tags, uint ntags )
		{
			StringFormat format = new StringFormat();

			if ( !fonts.ContainsKey( font ) ) return;

			Font gdiFont = fonts[font];
	
			format.Alignment = StringAlignment.Near;
			format.LineAlignment = StringAlignment.Near;

			y -= 2;
			RectangleF r = new RectangleF( (float)x, (float)y, 1000, 1000 );

			if ( ( flags & (uint)TEXTFLAG.SHADOW ) != 0 )
			{
				RectangleF rshadow = new RectangleF( (float)x + SHADOW_OFFSET, (float)( y + SHADOW_OFFSET ), 1000, 1000 );

				brush.Color = Color.Black;
				graphics.DrawString( text, gdiFont, brush, rshadow, format );
			}

			brush.Color = drawColour;
			graphics.DrawString( text, gdiFont, brush, r, format );
		}

		private static void MeasureText( UInt32 font, string text, out uint w, out uint h )
		{
			StringFormat format = new StringFormat();
			PointF origin = new PointF( 0, 0 );
			SizeF size;

			if ( !fonts.ContainsKey( font ) )
			{
				w = 1;
				h = 1;
				return;
			}

			Font gdiFont = fonts[font];
	
			format.Alignment = StringAlignment.Near;
			format.LineAlignment = StringAlignment.Near;
			format.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;

			size = graphics.MeasureString( text, gdiFont, origin, format );
	
			w = (uint)size.Width;
			h = (uint)size.Height;
		}

		private static IntPtr CreateRenderTarget( uint width, uint height )
		{
			return IntPtr.Zero;
		}

		private static void DestroyRenderTarget( IntPtr target )
		{
		}

		private static void DrawRenderTarget( IntPtr target, int x, int y, uint w, uint h )
		{
		}

		private static void EnableRenderTarget( IntPtr target, int x, int y )
		{
		}

		private static void DisableRenderTarget( IntPtr target )
		{
		}

		private static void ScreenPosToWorld( ref Vector3 src, out Vector3 dst )
		{
			dst = new Vector3();
		}

		private static void WorldPosToScreen( ref Vector3 src, out Vector3 dst )
		{
			dst = new Vector3();
		}

		// --------------------------------------------------
		// Renderer variables
		// -------------------------------------------------
		private static IRenderer handle;		// Renderer interface
		private static Form drawWindow;			// Window form
		private static Bitmap bitmap;			// Bitmap to draw to
		private static Graphics graphics;		// GDI+ graphics context
		private static Color drawColour;		// Draw colour
		private static SolidBrush brush;		// Brush used for drawing
		private static UInt32 fontIndex;		// Current font index
		private static Dictionary<uint,Font> fonts;	// List of loaded fonts
		//private static List<IntPtr> textures;	// List of loaded textures

		private const int SHADOW_OFFSET = 1;
	}
}
