using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MGUI
{
	public enum DRAWMODE
	{
		DRAWING_INVALID,
		DRAWING_2D,			// Draw 2D entities on top of everything else
		DRAWING_2D_DEPTH,	// Draw 2D entities, depth test enabled
		DRAWING_3D,			// Draw 3D entities (use with set_draw_transform)
	};
	
	public enum TEXTFLAG
	{
		NONE		= 0,
		TAGS		= 1 << 0,	// Text has format tag support
		SHADOW		= 1 << 1,	// Text has a shadow
		BOLD		= 1 << 2,	// Font used by the text is bold
		ITALIC		= 1 << 3,	// Font used by the text is cursive
	};

	public enum TAG
	{
		NONE		= 0,		// No special characteristics
		COLOUR		= 1 << 0,	// Tag specifies a custom colour
		COLOUR_END	= 1 << 1,	// Tag returns to default colour
		ULINE		= 1 << 2,	// Enable underlining
		ULINE_END	= 1 << 3,	// Enable underlining
	};

	[StructLayout( LayoutKind.Sequential )]
	public struct IRenderer
	{
		[MarshalAs( UnmanagedType.FunctionPtr )]
		public Begin begin;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public End end;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public Resize resize;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public SetDrawMode set_draw_mode;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public SetDrawColour set_draw_colour;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public SetDrawDepth set_draw_depth;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public SetDrawTransform set_draw_transform;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public ResetDrawTransform reset_draw_transform;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public StartClip start_clip;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public EndClip end_clip;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public DrawRect draw_rect;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public DrawTriangle draw_triangle;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public DrawPixel draw_pixel;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public LoadTexture load_texture;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public DestroyTexture destroy_texture;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public DrawTexturedRect draw_textured_rect;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public LoadFont load_font;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public DestroyFont destroy_font;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public DrawText draw_text;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public MeasureText measure_text;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public CreateRenderTarget create_render_target;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public DestroyRenderTarget destroy_render_target;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public DrawRenderTarget draw_render_target;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public EnableRenderTarget enable_render_target;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public DisableRenderTarget disable_render_target;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public ScreenPosToWorld screen_pos_to_world;

		[MarshalAs( UnmanagedType.FunctionPtr )]
		public WorldPosToScreen world_pos_to_screen;

		// --------------------------------------------------

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void Begin();

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void End();

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void Resize( uint width, uint height );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate DRAWMODE SetDrawMode( DRAWMODE mode );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void SetDrawColour( ref Math.Colour col );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void SetDrawDepth( float depth );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void SetDrawTransform( ref Math.Matrix4 mat );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void ResetDrawTransform();

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void StartClip( int x, int y, uint w, uint h );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void EndClip();

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void DrawRect( int x, int y, uint w, uint h );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void DrawTriangle( int x1, int y1, int x2, int y2, int x3, int y3 );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void DrawPixel( int x, int y );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate IntPtr LoadTexture( string path, out uint width, out uint height );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void DestroyTexture( IntPtr texture );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void DrawTexturedRect( IntPtr texture, int x, int y, uint w, uint h, float[] uv );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate UInt32 LoadFont( string font, uint size, uint flags, uint charset, uint firstc, uint lastc );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void DestroyFont( UInt32 font );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void DrawText( UInt32 font, string text, int x, int y, uint flags, IntPtr tags, uint ntags );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void MeasureText( UInt32 font, string text, out uint w, out uint h );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate IntPtr CreateRenderTarget( uint width, uint height );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void DestroyRenderTarget( IntPtr target );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void DrawRenderTarget( IntPtr target, int x, int y, uint w, uint h );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void EnableRenderTarget( IntPtr target, int x, int y );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void DisableRenderTarget( IntPtr target );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void ScreenPosToWorld( ref Math.Vector3 src, out Math.Vector3 dst );

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void WorldPosToScreen( ref Math.Vector3 src, out Math.Vector3 dst );
	};
}
