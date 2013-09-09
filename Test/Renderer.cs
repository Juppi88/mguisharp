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

		public static IRendererHandle Initialize( Form window, int width, int height )
		{
			// Prepare and fill the renderer API struct
			//handle = new IRendererHandle();

			//IRenderer.Begin begin = Begin;
			handle.begin = Begin;// Marshal.GetFunctionPointerForDelegate( begin );
			
			//IRenderer.End end = End;
			handle.end = End;// Marshal.GetFunctionPointerForDelegate( end );

			//IRenderer.Resize resize = Resize;
			handle.resize = Resize;// Marshal.GetFunctionPointerForDelegate( resize );

			IRenderer.SetDrawMode set_draw_mode = SetDrawMode;
			handle.set_draw_mode = SetDrawMode;// Marshal.GetFunctionPointerForDelegate( set_draw_mode );

			IRenderer.SetDrawColour set_draw_colour = SetDrawColour;
			handle.set_draw_colour = SetDrawColour;// Marshal.GetFunctionPointerForDelegate( set_draw_colour );

			handle.set_draw_depth = SetDrawDepth;

			IRenderer.SetDrawTransform set_draw_transform = SetDrawTransform;
			handle.set_draw_transform = SetDrawTransform;// Marshal.GetFunctionPointerForDelegate( set_draw_transform );

			IRenderer.ResetDrawTransform reset_draw_transform = ResetDrawTransform;
			handle.reset_draw_transform = ResetDrawTransform;// Marshal.GetFunctionPointerForDelegate( reset_draw_transform );

			IRenderer.StartClip start_clip = StartClip;
			handle.start_clip = StartClip;// Marshal.GetFunctionPointerForDelegate( start_clip );

			IRenderer.EndClip end_clip = EndClip;
			handle.end_clip = EndClip;//Marshal.GetFunctionPointerForDelegate( end_clip );

			IRenderer.DrawRect draw_rect = DrawRect;
			handle.draw_rect = DrawRect;// Marshal.GetFunctionPointerForDelegate( draw_rect );

			IRenderer.DrawTriangle draw_triangle = DrawTriangle;
			handle.draw_triangle = DrawTriangle;// Marshal.GetFunctionPointerForDelegate( draw_triangle );

			IRenderer.DrawPixel draw_pixel = DrawPixel;
			handle.draw_pixel = DrawPixel;// Marshal.GetFunctionPointerForDelegate( draw_pixel );

			IRenderer.LoadTexture load_texture = LoadTexture;
			handle.load_texture = LoadTexture;// Marshal.GetFunctionPointerForDelegate( load_texture );

			IRenderer.DestroyTexture destroy_texture = DestroyTexture;
			handle.destroy_texture = DestroyTexture;// Marshal.GetFunctionPointerForDelegate( destroy_texture );

			IRenderer.DrawTexturedRect draw_textured_rect = DrawTexturedRect;
			handle.draw_textured_rect = DrawTexturedRect;// GetFunctionPointerForDelegate( draw_textured_rect );

			//IRenderer.LoadFont load_font = LoadFont;
			handle.load_font = LoadFont;// LoadFont;// Marshal.GetFunctionPointerForDelegate( load_font );

			//IRenderer.DestroyFont destroy_font = DestroyFont;
			handle.destroy_font = DestroyFont;// DestroyFont;// Marshal.GetFunctionPointerForDelegate( destroy_font );

			//IRenderer.DrawText draw_text = DrawText;
			handle.draw_text = DrawText;// Marshal.GetFunctionPointerForDelegate( draw_text );

			//IRenderer.MeasureText measure_text = MeasureText;
			handle.measure_text = MeasureText;// Marshal.GetFunctionPointerForDelegate( measure_text );

			IRenderer.ScreenPosToWorld screen_pos_to_world = ScreenPosToWorld;
			handle.screen_pos_to_world = ScreenPosToWorld;// Marshal.GetFunctionPointerForDelegate( screen_pos_to_world );

			IRenderer.WorldPosToScreen world_pos_to_screen = WorldPosToScreen;
			handle.world_pos_to_screen = WorldPosToScreen;// Marshal.GetFunctionPointerForDelegate( world_pos_to_screen );

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

		private static void DrawTexturedRect( IntPtr texture, int x, int y, uint w, uint h, float u1, float v1, float u2, float v2 )
		{
		}

		private static UInt32 LoadFont( string font, uint size, uint flags, uint charset, uint firstc, uint lastc )
		{
			Font gdiFont;
			FontStyle style = 0;

			if ( ( flags & (uint)FONT.FFLAG_BOLD ) != 0 )	style |= FontStyle.Bold;
			if ( ( flags & (uint)FONT.FFLAG_ITALIC ) != 0 )	style |= FontStyle.Italic;
			if ( ( flags & (uint)FONT.FFLAG_ULINE ) != 0 )	style |= FontStyle.Underline;
			if ( ( flags & (uint)FONT.FFLAG_STRIKE ) != 0 )	style |= FontStyle.Strikeout;

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

			y -= 1;
			RectangleF r = new RectangleF( (float)x, (float)y, 1000, 1000 );

			if ( ( flags & (uint)TEXTFLAG.TFLAG_SHADOW ) != 0 )
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
		private static IRendererHandle handle;		// Renderer interface
		private static Form drawWindow;				// Window form
		private static Bitmap bitmap;				// Bitmap to draw to
		private static Graphics graphics;			// GDI+ graphics context
		private static Color drawColour;			// Draw colour
		private static SolidBrush brush;			// Brush used for drawing
		private static UInt32 fontIndex;				// Current font index
		private static Dictionary<uint,Font> fonts;	// List of loaded fonts
		//private static List<IntPtr> textures;		// List of loaded textures

		private const int SHADOW_OFFSET = 1;
	}
}
