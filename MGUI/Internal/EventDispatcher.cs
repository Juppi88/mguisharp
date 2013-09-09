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
			INPUT_CHANGE,	/* User modifies the text of an input element */
			INPUT_RETURN,	/* User presses return while an input element is focused */
			WINDOW_CLOSE,	/* Window is closed from the close button */
			FORCE_DWORD = 0x7FFFFFFF
		};

		[StructLayout( LayoutKind.Explicit )]
		public struct GuiEventArgs
		{
			[FieldOffset(0)] public MGUI_EVENT	type;		// Event type
			[FieldOffset(4)] public IntPtr		element;	// The element which triggered this event
			[FieldOffset(8)] public IntPtr		data;		// User specified data
			[FieldOffset(12)] public short		mouseX;		// Mouse cursor X co-ordinate
			[FieldOffset(14)] public short		mouseY;		// Mouse cursor Y co-ordinate
			[FieldOffset(12)] public uint		key;		// Pressed key
		}
		
		private static void ProcessEvents( ref GuiEventArgs args )
		{
			if ( !elements.ContainsKey( args.element ) ) return;

			Element element = elements[args.element];
			element.HandleEvent( ref args );			
		}

		private void HandleEvent( ref GuiEventArgs args )
		{
			switch ( args.type )
			{
				case MGUI_EVENT.HOVER_ENTER:
					if ( OnMouseEnter != null )
					{
						CursorEventArgs data = new CursorEventArgs( args.mouseX, args.mouseY );
						OnMouseEnter( this, data );
					}
					break;

				case MGUI_EVENT.HOVER_LEAVE:
					if ( OnMouseLeave != null )
					{
						CursorEventArgs data = new CursorEventArgs( args.mouseX, args.mouseY );
						OnMouseLeave( this, data );
					}
					break;

				case MGUI_EVENT.CLICK:
					if ( OnMouseClick != null )
					{
						CursorEventArgs data = new CursorEventArgs( args.mouseX, args.mouseY );
						OnMouseClick( this, data );
					}
					break;

				case MGUI_EVENT.RELEASE:
					if ( OnMouseRelease != null )
					{
						CursorEventArgs data = new CursorEventArgs( args.mouseX, args.mouseY );
						OnMouseRelease( this, data );
					}
					break;

				case MGUI_EVENT.DRAG:
					if ( OnDrag != null )
					{
						CursorEventArgs data = new CursorEventArgs( args.mouseX, args.mouseY );
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

				case MGUI_EVENT.INPUT_CHANGE:
					if ( OnInputTextChange != null )
					{
						EventArgs data = new EventArgs();
						OnInputTextChange( this, data );
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
}
