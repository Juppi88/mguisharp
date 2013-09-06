using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MGUI
{
	[StructLayout( LayoutKind.Explicit )]
	public struct IRendererHandle
	{
		[FieldOffset(0)] public IntPtr begin;
		[FieldOffset(4)] public IntPtr end;
		[FieldOffset(8)] public IntPtr resize;

		[FieldOffset(12)] public IntPtr set_draw_mode;
		[FieldOffset(16)] public IntPtr set_draw_colour;
		[FieldOffset(20)] public IntPtr set_draw_depth;
		[FieldOffset(24)] public IntPtr set_draw_transform;
		[FieldOffset(28)] public IntPtr reset_draw_transform;

		[FieldOffset(32)] public IntPtr start_clip;
		[FieldOffset(36)] public IntPtr end_clip;

		[FieldOffset(40)] public IntPtr draw_rect;
		[FieldOffset(44)] public IntPtr draw_triangle;
		[FieldOffset(48)] public IntPtr draw_pixel;

		[FieldOffset(52)] public IntPtr load_texture;
		[FieldOffset(56)] public IntPtr destroy_texture;
		[FieldOffset(60)] public IntPtr draw_textured_rect;

		[FieldOffset(64)] public IntPtr load_font;
		[FieldOffset(68)] public IntPtr destroy_font;
		[FieldOffset(72)] public IntPtr draw_text;
		[FieldOffset(76)] public IntPtr measure_text;

		[FieldOffset(80)] public IntPtr screen_pos_to_world;
		[FieldOffset(84)] public IntPtr world_pos_to_screen;
	};

	public enum DRAWMODE
	{
		DRAWING_INVALID,
		DRAWING_2D,			// Draw 2D entities on top of everything else
		DRAWING_2D_DEPTH,	// Draw 2D entities, depth test enabled
		DRAWING_3D,			// Draw 3D entities (use with set_draw_transform)
	};

	public sealed class IRenderer
	{
		public delegate void Begin();
		public delegate void End();
		public delegate void Resize( uint width, uint height );

		public delegate DRAWMODE SetDrawMode( DRAWMODE mode );
		public delegate void SetDrawColour( ref Math.Colour col );
		public delegate void SetDrawDepth( float depth );
		public delegate void SetDrawTransform( ref Math.Matrix4 mat );
		public delegate void ResetDrawTransform();

		public delegate void StartClip( int x, int y, uint w, uint h );
		public delegate void EndClip();

		public delegate void DrawRect( int x, int y, uint w, uint h );
		public delegate void DrawTriangle( int x1, int y1, int x2, int y2, int x3, int y3 );
		public delegate void DrawPixel( int x, int y );

		public delegate IntPtr LoadTexture( string path, out uint width, out uint height );
		public delegate void DestroyTexture( IntPtr texture );
		public delegate void DrawTexturedRect( IntPtr texture, int x, int y, uint w, uint h, float u1, float v1, float u2, float v2 );

		public delegate IntPtr LoadFont( string font, uint size, uint flags, uint charset, uint firstc, uint lastc );
		public delegate void DestroyFont( IntPtr font );
		public delegate void DrawText( IntPtr font, string text, int x, int y, uint flags, IntPtr tags, uint ntags );
		public delegate void MeasureText( IntPtr font, string text, out uint w, out uint h );

		public delegate void ScreenPosToWorld( ref Math.Vector3 src, out Math.Vector3 dst );
		public delegate void WorldPosToScreen( ref Math.Vector3 src, out Math.Vector3 dst );
	};
}
