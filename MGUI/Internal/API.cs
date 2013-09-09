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

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_initialize( IntPtr wndhandle, uint parameters );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_shutdown();

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_process();

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_force_redraw();

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_renderer( ref IRenderer renderer );

		[DllImport( "mgui.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_skin( string skinimg );


		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern IntPtr mgui_get_focus();

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_focus( IntPtr element );

		// --------------------------------------------------
		// Element constructors
		// --------------------------------------------------

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern IntPtr mgui_create_button( IntPtr parent );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern IntPtr mgui_create_button_ex( IntPtr parent, short x, short y, ushort w, ushort h, uint flags, uint col, string text );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern IntPtr mgui_create_canvas( IntPtr parent );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern IntPtr mgui_create_editbox( IntPtr parent );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern IntPtr mgui_create_editbox_ex( IntPtr parent, short x, short y, ushort w, ushort h, uint flags, uint col, string text );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern IntPtr mgui_create_label( IntPtr parent );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern IntPtr mgui_create_label_ex( IntPtr parent, short x, short y, ushort w, ushort h, uint flags, uint col, string text );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern IntPtr mgui_create_memobox( IntPtr parent );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern IntPtr mgui_create_memobox_ex( IntPtr parent, short x, short y, ushort w, ushort h, uint flags, uint col );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_element_destroy( IntPtr element );

		// --------------------------------------------------
		// Generic element functions
		// --------------------------------------------------

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_get_pos( IntPtr element, out Math.Vector2 pos );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_get_size( IntPtr element, out Math.Vector2 size );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_pos( IntPtr element, ref Math.Vector2 pos );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_size( IntPtr element, ref Math.Vector2 size );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_get_abs_pos( IntPtr element, out Math.VectorScreen pos );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_get_abs_size( IntPtr element, out Math.VectorScreen size );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_abs_pos( IntPtr element, ref Math.VectorScreen pos );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_abs_size( IntPtr element, ref Math.VectorScreen size );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_get_pos_f( IntPtr element, out float x, out float y );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_get_size_f( IntPtr element, out float w, out float h );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_pos_f( IntPtr element, float x, float y );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_size_f( IntPtr element, float w, float h );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_get_abs_pos_i( IntPtr element, out short x, out short y );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_get_abs_size_i( IntPtr element, out ushort w, out ushort h );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_abs_pos_i( IntPtr element, short x, short y );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_abs_size_i( IntPtr element, ushort w, ushort h );


		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_get_colour( IntPtr element, out Math.Colour col );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_colour( IntPtr element, ref Math.Colour col );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_get_text_colour( IntPtr element, out Math.Colour col );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_text_colour( IntPtr element, ref Math.Colour col );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern byte mgui_get_alpha( IntPtr element );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_alpha( IntPtr element, byte alpha );


		[DllImport( "mgui.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl )]
		public static extern IntPtr mgui_get_text( IntPtr element );

		[DllImport( "mgui.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_text_s( IntPtr element, string text );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern uint mgui_get_text_len( IntPtr element );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_get_text_size( IntPtr element, out Math.VectorScreen size );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern uint mgui_get_alignment( IntPtr element );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_alignment( IntPtr element, uint alignment );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_get_text_padding( IntPtr element, out byte top, out byte bottom, out byte left, out byte right );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_text_padding( IntPtr element, byte top, byte bottom, byte left, byte right );


		[DllImport( "mgui.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl )]
		public static extern IntPtr mgui_get_font_name( IntPtr element );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern byte mgui_get_font_size( IntPtr element );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern byte mgui_get_font_flags( IntPtr element );

		[DllImport( "mgui.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_font_name( IntPtr element, string font );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_font_size( IntPtr element, byte size );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_font_flags( IntPtr element, byte flags );

		[DllImport( "mgui.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_font( IntPtr element, string font, byte size, byte flags, byte charset );


		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern uint mgui_get_flags( IntPtr element );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern uint mgui_add_flags( IntPtr element, uint flags );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern uint mgui_remove_flags( IntPtr element, uint flags );

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_set_event_handler( IntPtr element, Element.GuiEventHandler handler, IntPtr data );

		// --------------------------------------------------
		// Label functions
		// --------------------------------------------------

		[DllImport( "mgui.dll", CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_label_make_text_fit( IntPtr label );

		// --------------------------------------------------
		// Memobox functions
		// --------------------------------------------------

		[DllImport( "mgui.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_memobox_add_line_s( IntPtr memobox, string text );

		[DllImport( "mgui.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl )]
		public static extern void mgui_memobox_add_line_col_s( IntPtr memobox, string text, ref Math.Colour col );
	}
}
