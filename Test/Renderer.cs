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

namespace TestApp
{
	// Take a look at IRenderer in IRenderer.cs for the renderer function 'prototypes'.
	static class Renderer
	{
		// --------------------------------------------------
		// Initialization methods
		// --------------------------------------------------

		public static void Initialize( Form window, int width, int height )
		{
			// Prepare and fill the renderer API struct
			handle = new IRendererHandle();

			IRenderer.Begin begin = Begin;
			handle.begin = Marshal.GetFunctionPointerForDelegate( begin );

			IRenderer.End end = End;
			handle.end = Marshal.GetFunctionPointerForDelegate( end );

			IRenderer.Resize resize = Resize;
			handle.resize = Marshal.GetFunctionPointerForDelegate( resize );

			IRenderer.SetDrawMode set_draw_mode = SetDrawMode;
			handle.set_draw_mode = Marshal.GetFunctionPointerForDelegate( set_draw_mode );

			IRenderer.SetDrawColour set_draw_colour = SetDrawColour;
			handle.set_draw_colour = Marshal.GetFunctionPointerForDelegate( set_draw_colour );

			IRenderer.SetDrawTransform set_draw_transform = SetDrawTransform;
			handle.set_draw_transform = Marshal.GetFunctionPointerForDelegate( set_draw_transform );

			IRenderer.ResetDrawTransform reset_draw_transform = ResetDrawTransform;
			handle.reset_draw_transform = Marshal.GetFunctionPointerForDelegate( reset_draw_transform );

			IRenderer.StartClip start_clip = StartClip;
			handle.start_clip = Marshal.GetFunctionPointerForDelegate( start_clip );

			IRenderer.EndClip end_clip = EndClip;
			handle.end_clip = Marshal.GetFunctionPointerForDelegate( end_clip );

			IRenderer.DrawRect draw_rect = DrawRect;
			handle.draw_rect = Marshal.GetFunctionPointerForDelegate( draw_rect );

			IRenderer.DrawTriangle draw_triangle = DrawTriangle;
			handle.draw_triangle = Marshal.GetFunctionPointerForDelegate( draw_triangle );

			IRenderer.DrawPixel draw_pixel = DrawPixel;
			handle.draw_pixel = Marshal.GetFunctionPointerForDelegate( draw_pixel );

			IRenderer.LoadTexture load_texture = LoadTexture;
			handle.load_texture = Marshal.GetFunctionPointerForDelegate( load_texture );

			IRenderer.DestroyTexture destroy_texture = DestroyTexture;
			handle.destroy_texture = Marshal.GetFunctionPointerForDelegate( destroy_texture );

			IRenderer.DrawTexturedRect draw_textured_rect = DrawTexturedRect;
			handle.draw_textured_rect = Marshal.GetFunctionPointerForDelegate( draw_textured_rect );

			IRenderer.LoadFont load_font = LoadFont;
			handle.load_font = Marshal.GetFunctionPointerForDelegate( load_font );

			IRenderer.DestroyFont destroy_font = DestroyFont;
			handle.destroy_font = Marshal.GetFunctionPointerForDelegate( destroy_font );

			IRenderer.DrawText draw_text = DrawText;
			handle.draw_text = Marshal.GetFunctionPointerForDelegate( draw_text );

			IRenderer.MeasureText measure_text = MeasureText;
			handle.measure_text = Marshal.GetFunctionPointerForDelegate( measure_text );

			IRenderer.ScreenPosToWorld screen_pos_to_world = ScreenPosToWorld;
			handle.screen_pos_to_world = Marshal.GetFunctionPointerForDelegate( screen_pos_to_world );

			IRenderer.WorldPosToScreen world_pos_to_screen = WorldPosToScreen;
			handle.world_pos_to_screen = Marshal.GetFunctionPointerForDelegate( world_pos_to_screen );

			// Prepare graphics
			Graphics gc = window.CreateGraphics();

			bitmap = new Bitmap( width, height, gc );
			graphics = Graphics.FromImage( bitmap );
			brush = new SolidBrush( Color.White );
			drawWindow = window;

			gc.Dispose();
		}

		public static void Shutdown()
		{
			graphics.Dispose();
		}

		public static IRendererHandle Handle
		{
			get { return handle; }
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
			graphics.Clear( Color.Black );

			gc.DrawImage( bitmap, 0, 0 );
			gc.Dispose();
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

		private static void DrawTexturedRect( IntPtr texture, int x, int y, uint w, uint h, float u1, float v1, float u2, float v2 )
		{
		}

		private static IntPtr LoadFont( string font, uint size, uint flags, uint charset, uint firstc, uint lastc )
		{
			return IntPtr.Zero;
		}

		private static void DestroyFont( IntPtr font )
		{
		}

		private static void DrawText( IntPtr font, string text, int x, int y, uint flags, IntPtr tags, uint ntags )
		{
		}

		private static void MeasureText( IntPtr font, string text, out uint w, out uint h )
		{
			w = 1;
			h = 1;
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
		private static IRendererHandle handle;	// Renderer interface
		private static Form drawWindow;			// Window form
		private static Bitmap bitmap;			// Bitmap to draw to
		private static Graphics graphics;		// GDI+ graphics context
		private static Color drawColour;		// Draw colour
		private static SolidBrush brush;		// Brush used for drawing
	}
}
