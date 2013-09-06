using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MGUI
{
	public class API
	{
		// --------------------------------------------------
		// Library initialization and processing
		// --------------------------------------------------
		
		[DllImport( "mgui.dll" )]
		public static extern void mgui_initialize( IntPtr wndhandle, uint parameters );
		
		[DllImport( "mgui.dll" )]
		public static extern void mgui_shutdown();

		[DllImport( "mgui.dll" )]
		public static extern void mgui_process();

		[DllImport( "mgui.dll" )]
		public static extern void mgui_force_redraw();

		[DllImport( "mgui.dll" )]
		public static extern void mgui_set_renderer( ref IRendererHandle renderer );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_set_skin( string skinimg );

		// --------------------------------------------------
		// Element constructors
		// --------------------------------------------------

		[DllImport( "mgui.dll" )]
		public static extern IntPtr mgui_create_label( IntPtr? parent );

		[DllImport( "mgui.dll" )]
		public static extern IntPtr mgui_create_label_ex( IntPtr? parent, short x, short y, ushort w, ushort h, uint flags, uint col, string text );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_element_destroy( IntPtr element );

		// --------------------------------------------------
		// Generic element functions
		// --------------------------------------------------

		[DllImport( "mgui.dll" )]
		public static extern void mgui_get_pos( IntPtr element, out Math.Vector2 pos );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_get_size( IntPtr element, out Math.Vector2 size );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_set_pos( IntPtr element, ref Math.Vector2 pos );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_set_size( IntPtr element, ref Math.Vector2 size );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_get_abs_pos( IntPtr element, out Math.VectorScreen pos );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_get_abs_size( IntPtr element, out Math.VectorScreen size );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_set_abs_pos( IntPtr element, ref Math.VectorScreen pos );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_set_abs_size( IntPtr element, ref Math.VectorScreen size );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_get_pos_f( IntPtr element, out float x, out float y );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_get_size_f( IntPtr element, out float w, out float h );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_set_pos_f( IntPtr element, float x, float y );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_set_size_f( IntPtr element, float w, float h );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_get_abs_pos_i( IntPtr element, out short x, out short y );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_get_abs_size_i( IntPtr element, out ushort w, out ushort h );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_set_abs_pos_i( IntPtr element, short x, short y );

		[DllImport( "mgui.dll" )]
		public static extern void mgui_set_abs_size_i( IntPtr element, ushort w, ushort h );

		// --------------------------------------------------
		// Label functions
		// --------------------------------------------------

		[DllImport( "mgui.dll" )]
		public static extern void mgui_label_make_text_fit( IntPtr label );
	}
}
