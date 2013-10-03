using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGUI.Math;

namespace MGUI
{
	public partial class Window : Element
	{
		public Window( Element parentElement )
		{
			Handle = API.mgui_create_window( parentElement.Handle );
		}

		public Window( Element parentElement, VectorScreen absPos, VectorScreen absSize, ELEMFLAG flags, Colour col, string text )
		{
			Handle = API.mgui_create_window_ex( parentElement.Handle, absPos.x, absPos.y, (ushort)absSize.x, (ushort)absSize.y, (uint)flags, col.AsHex(), text );
		}

		public Colour TitlebarColour
		{
			get { Colour col; API.mgui_window_get_title_col( Handle, out col ); return col; }
			set { API.mgui_window_set_title_col( Handle, ref value ); }
		}

		public VectorScreen DragOffset
		{
			get { VectorScreen pos; API.mgui_window_get_drag_offset( Handle, out pos ); return pos; }
		}

		// --------------------------------------------------
		// Events
		// --------------------------------------------------

		public event EventHandler		OnClose;
		public event ResizeEventHandler	OnResize;
	}
}
