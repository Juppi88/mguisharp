using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MGUI
{
	public partial class Element
	{
		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		public delegate void GuiEventHandler( ref GuiEventArgs args );

		public enum MGUI_EVENT
		{
			HOVER_ENTER,	/* Mouse enters the element boundaries */
			HOVER_LEAVE,	/* Mouse leaves the element boundaries */
			CLICK,			/* Element is clicked (lmb down) */
			RELEASE,		/* Element is released (lmb up) */
			DRAG,			/* Element is dragged */
			FOCUS_ENTER,	/* Element receives focus */
			FOCUS_EXIT,		/* Element loses focus */
			CHECBOX_TOGGLE,	/* Checkbox is toggled */
			INPUT_RETURN,	/* User presses return while an input element is focused */
			LISTBOX_SELECT,	/* A listbox item was selected */
			SCROLL,			/* Scrollable element was moved */
			WINDOW_CLOSE,	/* Window is closed from the close button */
			WINDOW_RESIZE,	/* Window is resized by the user */
			FORCE_DWORD = 0x7FFFFFFF
		};

		[StructLayout( LayoutKind.Explicit )]
		public struct GuiEventArgs
		{
			[FieldOffset(0)] public MGUI_EVENT	type;			// Event type
			[FieldOffset(4)] public IntPtr		element;		// The element which triggered this event
			[FieldOffset(8)] public IntPtr		data;			// User specified data
			[FieldOffset(12)] public short		mouseCursorX;	// Mouse cursor X co-ordinate
			[FieldOffset(14)] public short		mouseCursorY;	// Mouse cursor Y co-ordinate
			[FieldOffset(12)] public uint		key;			// Pressed key
			[FieldOffset(12)] public ushort		resizeWidth;	// Window width after resizing
			[FieldOffset(14)] public ushort		resizeHeight;	// Window height after resizing
			[FieldOffset(12)] public IntPtr		listItem;		// Pointer to listbox item
			[FieldOffset(12)] public float		scrollPos;		// Scrollbar position
			[FieldOffset(16)] public float		scrollChange;	// Scrollbar position change
		}
		
		private static void ProcessEvents( ref GuiEventArgs args )
		{
			if ( !elements.ContainsKey( args.element ) ) return;

			Element element = elements[args.element];
			element.HandleEvent( ref args );			
		}

		protected virtual void HandleEvent( ref GuiEventArgs args )
		{
			switch ( args.type )
			{
				case MGUI_EVENT.HOVER_ENTER:
					if ( OnMouseEnter != null )
					{
						CursorEventArgs data = new CursorEventArgs( args.mouseCursorX, args.mouseCursorY );
						OnMouseEnter( this, data );
					}
					break;

				case MGUI_EVENT.HOVER_LEAVE:
					if ( OnMouseLeave != null )
					{
						CursorEventArgs data = new CursorEventArgs( args.mouseCursorX, args.mouseCursorY );
						OnMouseLeave( this, data );
					}
					break;

				case MGUI_EVENT.CLICK:
					if ( OnMouseClick != null )
					{
						CursorEventArgs data = new CursorEventArgs( args.mouseCursorX, args.mouseCursorY );
						OnMouseClick( this, data );
					}
					break;

				case MGUI_EVENT.RELEASE:
					if ( OnMouseRelease != null )
					{
						CursorEventArgs data = new CursorEventArgs( args.mouseCursorX, args.mouseCursorY );
						OnMouseRelease( this, data );
					}
					break;

				case MGUI_EVENT.DRAG:
					if ( OnDrag != null )
					{
						CursorEventArgs data = new CursorEventArgs( args.mouseCursorX, args.mouseCursorY );
						OnDrag( this, data );
					}
					break;

				case MGUI_EVENT.FOCUS_ENTER:
					if ( OnFocusEnter != null )
					{
						EventArgs data = new EventArgs();
						OnFocusEnter( this, data );
					}
					break;

				case MGUI_EVENT.FOCUS_EXIT:
					if ( OnFocusExit != null )
					{
						EventArgs data = new EventArgs();
						OnFocusExit( this, data );
					}
					break;

				case MGUI_EVENT.INPUT_RETURN:
					if ( OnInputTextReturn != null )
					{
						EventArgs data = new EventArgs();
						OnInputTextReturn( this, data );
					}
					break;
			}
		}

		private void InitializeEvents()
		{
			if ( elements == null )
			{
				// Initialize the dictionary first
				elements = new Dictionary<IntPtr, Element>();
			}

			elements.Add( elementHandle, this );
			API.mgui_set_event_handler( elementHandle, ProcessEvents, IntPtr.Zero );
		}

		private void DeinitializeEvents()
		{
			if ( elements.ContainsKey( elementHandle ) )
			{
				elements.Remove( elementHandle );
			}
		}

		private static Dictionary<IntPtr, Element> elements;
	}

	// --------------------------------------------------
	// Checkbox events
	// --------------------------------------------------

	public partial class Checkbox : Element
	{
		protected override void HandleEvent( ref GuiEventArgs args )
		{
			base.HandleEvent( ref args );

			switch ( args.type )
			{
				case MGUI_EVENT.CHECBOX_TOGGLE:
					if ( OnToggle != null )
					{
						EventArgs data = new EventArgs();
						OnToggle( this, data );
					}
					break;
			}
		}
	}

	// --------------------------------------------------
	// Listbox events
	// --------------------------------------------------

	public partial class Listbox : Element
	{
		protected override void HandleEvent( ref GuiEventArgs args )
		{
			base.HandleEvent( ref args );

			switch ( args.type )
			{
				case MGUI_EVENT.LISTBOX_SELECT:
					if ( OnItemSelect != null )
					{
						ListboxItem item = GetItemFromPointer( args.listItem );
						if ( item != ListboxItem.Null )
						{
							ListEventArgs data = new ListEventArgs( item );
							OnItemSelect( this, data );
						}
					}
					break;
			}
		}
	}

	// --------------------------------------------------
	// Scrollbar events
	// --------------------------------------------------

	public partial class Scrollbar : Element
	{
		protected override void HandleEvent( ref GuiEventArgs args )
		{
			base.HandleEvent( ref args );

			switch ( args.type )
			{
				case MGUI_EVENT.SCROLL:
					if ( OnScroll != null )
					{
						ScrollEventArgs data = new ScrollEventArgs( args.scrollPos, args.scrollChange );
						OnScroll( this, data );
					}
					break;
			}
		}
	}
	
	// --------------------------------------------------
	// Window events
	// --------------------------------------------------

	public partial class Window : Element
	{
		protected override void HandleEvent( ref GuiEventArgs args )
		{
			base.HandleEvent( ref args );

			switch ( args.type )
			{
				case MGUI_EVENT.WINDOW_CLOSE:
					if ( OnClose != null )
					{
						EventArgs data = new EventArgs();
						OnClose( this, data );
					}
					break;

				case MGUI_EVENT.WINDOW_RESIZE:
					if ( OnResize != null )
					{
						ResizeEventArgs data = new ResizeEventArgs( args.resizeWidth, args.resizeHeight );
						OnResize( this, data );
					}
					break;
			}
		}
	}
}
