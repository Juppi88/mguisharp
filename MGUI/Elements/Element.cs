using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using MGUI.Math;

namespace MGUI
{
    public partial class Element : IDisposable
    {
		public Element()
		{
			elementHandle = IntPtr.Zero;
		}

		~Element()
		{
			if ( elementHandle != IntPtr.Zero )
			{
				Dispose();
			}
		}

		public void Dispose()
		{
			DeinitializeEvents();
			API.mgui_element_destroy( elementHandle );

			elementHandle = IntPtr.Zero;
		}

		// --------------------------------------------------
		// Parent/children relations
		// --------------------------------------------------

		public void AddChild( Element child )
		{
			if ( child != Element.Null )
				API.mgui_add_child( elementHandle, child.Handle );
		}

		public void RemoveFromParent()
		{
			API.mgui_remove_child( elementHandle );
		}

		public void MoveForward()
		{
			API.mgui_move_forward( elementHandle );
		}

		public void MoveBackward()
		{
			API.mgui_move_backward( elementHandle );
		}

		public void SendToTop()
		{
			API.mgui_send_to_top( elementHandle );
		}

		public void SendToBottom()
		{
			API.mgui_send_to_bottom( elementHandle );
		}

		public bool IsChildOf( Element parent )
		{
			if ( parent == Element.Null ) return false;
			return API.mgui_is_child_of( parent.Handle, elementHandle );
		}

		// --------------------------------------------------
		// Element focus
		// --------------------------------------------------

		public bool Focus
		{
			get { if ( API.mgui_get_focus() == elementHandle ) return true; return false; }
			set { if ( value ) API.mgui_set_focus( elementHandle ); else API.mgui_set_focus( IntPtr.Zero ); }
		}

		public static Element GetFocusElement()
		{
			IntPtr element = API.mgui_get_focus();

			if ( elements.ContainsKey( element ) )
				return elements[element];

			return null;
		}

		// --------------------------------------------------
		// Position and size
		// --------------------------------------------------

		public Vector2 Pos
		{
			get { Vector2 pos; API.mgui_get_pos( elementHandle, out pos ); return pos; }
			set { API.mgui_set_pos( elementHandle, ref value ); }
		}

		public Vector2 Size
		{
			get { Vector2 size; API.mgui_get_size( elementHandle, out size ); return size; }
			set { API.mgui_set_size( elementHandle, ref value ); }
		}

		public VectorScreen AbsolutePos
		{
			get { VectorScreen pos; API.mgui_get_abs_pos( elementHandle, out pos ); return pos; }
			set { API.mgui_set_abs_pos( elementHandle, ref value ); }
		}

		public VectorScreen AbsoluteSize
		{
			get { VectorScreen size; API.mgui_get_abs_size( elementHandle, out size ); return size; }
			set { API.mgui_set_abs_size( elementHandle, ref value ); }
		}

		// --------------------------------------------------
		// 3D/depth properties
		// --------------------------------------------------

		public float Depth
		{
			get { return API.mgui_get_z_depth( elementHandle ); }
			set { API.mgui_set_z_depth( elementHandle, value ); }
		}

		// --------------------------------------------------
		// Colour
		// --------------------------------------------------

		public Colour Colour
		{
			get { Colour col; API.mgui_get_colour( elementHandle, out col ); return col; }
			set { API.mgui_set_colour( elementHandle, ref value ); }
		}

		public Colour TextColour
		{
			get { Colour col; API.mgui_get_text_colour( elementHandle, out col ); return col; }
			set { API.mgui_set_text_colour( elementHandle, ref value ); }
		}

		public byte Alpha
		{
			get { return API.mgui_get_alpha( elementHandle ); }
			set { API.mgui_set_alpha( elementHandle, value ); }
		}

		// --------------------------------------------------
		// Text and font
		// --------------------------------------------------

		public string Text
		{
			get { IntPtr text = API.mgui_get_text( elementHandle ); return Marshal.PtrToStringAnsi( text ); }
			set { API.mgui_set_text_s( elementHandle, value ); }
		}

		public uint TextLength
		{
			get { return API.mgui_get_text_len( elementHandle ); }
		}

		public VectorScreen TextSize
		{
			get { VectorScreen size; API.mgui_get_text_size( elementHandle, out size ); return size; }
		}

		public uint Alignment
		{
			get { return API.mgui_get_alignment( elementHandle ); }
			set { API.mgui_set_alignment( elementHandle, value ); }
		}

		public void GetPadding( out byte top, out byte bottom, out byte left, out byte right )
		{
			API.mgui_get_text_padding( elementHandle, out top, out bottom, out left, out right );
		}

		public void SetPadding( byte top, byte bottom, byte left, byte right )
		{
			API.mgui_set_text_padding( elementHandle, top, bottom, left, right );
		}

		public string FontName
		{
			get { IntPtr text = API.mgui_get_font_name( elementHandle ); return Marshal.PtrToStringAnsi( text ); }
			set { API.mgui_set_font_name( elementHandle, value ); }
		}

		public byte FontSize
		{
			get { return API.mgui_get_font_size( elementHandle ); }
			set { API.mgui_set_font_size( elementHandle, value ); }
		}

		public byte FontFlags
		{
			get { return API.mgui_get_font_flags( elementHandle ); }
			set { API.mgui_set_font_flags( elementHandle, value ); }
		}

		public void SetFont( string fontName, byte fontSize, FONTFLAG fontFlags, byte charset = 0 )
		{
			API.mgui_set_font( elementHandle, fontName, fontSize, (byte)fontFlags, charset );
		}

		// --------------------------------------------------
		// Element flags
		// --------------------------------------------------

		public uint Flags
		{
			get { return API.mgui_get_flags( elementHandle ); }
		}

		public void AddFlags( ELEMFLAG flags )
		{
			API.mgui_add_flags( elementHandle, (uint)flags );
		}

		public void RemoveFlags( ELEMFLAG flags )
		{
			API.mgui_remove_flags( elementHandle, (uint)flags );
		}

		public bool GetFlag( ELEMFLAG flag )
		{
			return ( API.mgui_get_flags( elementHandle ) & (uint)flag ) != 0;
		}

		public void SetFlag( ELEMFLAG flag, bool toggle )
		{
			if ( toggle )
				API.mgui_add_flags( elementHandle, (uint)flag );
			else
				API.mgui_remove_flags( elementHandle, (uint)flag );
		}

		// --------------------------------------------------
		// Element flag properties
		// --------------------------------------------------

		public bool Visible
		{
			get { return GetFlag( ELEMFLAG.VISIBLE ); }
			set { SetFlag( ELEMFLAG.VISIBLE, value ); }
		}

		public bool Disabled
		{
			get { return GetFlag( ELEMFLAG.DISABLED ); }
			set { SetFlag( ELEMFLAG.DISABLED, value ); }
		}

		public bool Background
		{
			get { return GetFlag( ELEMFLAG.BACKGROUND ); }
			set { SetFlag( ELEMFLAG.BACKGROUND, value ); }
		}

		public bool Border
		{
			get { return GetFlag( ELEMFLAG.BORDER ); }
			set { SetFlag( ELEMFLAG.BORDER, value ); }
		}

		public bool Shadow
		{
			get { return GetFlag( ELEMFLAG.SHADOW ); }
			set { SetFlag( ELEMFLAG.SHADOW, value ); }
		}

		public bool Draggable
		{
			get { return GetFlag( ELEMFLAG.DRAGGABLE ); }
			set { SetFlag( ELEMFLAG.DRAGGABLE, value ); }
		}

		public bool Clip
		{
			get { return GetFlag( ELEMFLAG.CLIP ); }
			set { SetFlag( ELEMFLAG.CLIP, value ); }
		}

		public bool WordWrap
		{
			get { return GetFlag( ELEMFLAG.WRAP ); }
			set { SetFlag( ELEMFLAG.WRAP, value ); }
		}

		public bool AutoResize
		{
			get { return GetFlag( ELEMFLAG.AUTO_RESIZE ); }
			set { SetFlag( ELEMFLAG.AUTO_RESIZE, value ); }
		}

		public bool InheritAlpha
		{
			get { return GetFlag( ELEMFLAG.INHERIT_ALPHA ); }
			set { SetFlag( ELEMFLAG.INHERIT_ALPHA, value ); }
		}

		public bool Animation
		{
			get { return GetFlag( ELEMFLAG.ANIMATION ); }
			set { SetFlag( ELEMFLAG.ANIMATION, value ); }
		}

		public bool TabStop
		{
			get { return GetFlag( ELEMFLAG.TABSTOP ); }
			set { SetFlag( ELEMFLAG.TABSTOP, value ); }
		}

		public bool MouseControl
		{
			get { return GetFlag( ELEMFLAG.MOUSECTRL ); }
			set { SetFlag( ELEMFLAG.MOUSECTRL, value ); }
		}

		public bool KeyboardControl
		{
			get { return GetFlag( ELEMFLAG.KBCTRL ); }
			set { SetFlag( ELEMFLAG.KBCTRL, value ); }
		}

		public bool TextShadow
		{
			get { return GetFlag( ELEMFLAG.TEXT_SHADOW ); }
			set { SetFlag( ELEMFLAG.TEXT_SHADOW, value ); }
		}

		public bool TextTags
		{
			get { return GetFlag( ELEMFLAG.TEXT_TAGS ); }
			set { SetFlag( ELEMFLAG.TEXT_TAGS, value ); }
		}

		public bool DepthTest
		{
			get { return GetFlag( ELEMFLAG.DEPTH_TEST ); }
			set { SetFlag( ELEMFLAG.DEPTH_TEST, value ); }
		}

		public bool Is3D
		{
			get { return GetFlag( ELEMFLAG.DRAW_3D ); }
			set { SetFlag( ELEMFLAG.DRAW_3D, value ); }
		}

		public bool UseCacheTexture
		{
			get { return GetFlag( ELEMFLAG.CACHE_TEXTURE ); }
			set { SetFlag( ELEMFLAG.CACHE_TEXTURE, value ); }
		}

		// --------------------------------------------------
		// Events
		// --------------------------------------------------

		public event CursorEventHandler OnMouseEnter;
		public event CursorEventHandler OnMouseLeave;
		public event CursorEventHandler OnMouseClick;
		public event CursorEventHandler OnMouseRelease;
		public event CursorEventHandler OnDrag;
		public event EventHandler OnFocusEnter;
		public event EventHandler OnFocusExit;
		public event EventHandler OnInputTextReturn;

		// --------------------------------------------------
		// Internal
		// --------------------------------------------------

		public IntPtr Handle
		{
			get { return elementHandle; }
			set { if ( value != IntPtr.Zero ) { elementHandle = value; InitializeEvents(); } }
		}

		// Handle to the internal MGUI element struct
		private IntPtr elementHandle;

		// A null element (can be used as a parent)
		public static Element Null;
    }
}
