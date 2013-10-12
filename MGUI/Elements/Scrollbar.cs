using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGUI.Math;

namespace MGUI
{
	public partial class Scrollbar : Element
	{
		public Scrollbar( Element parentElement )
		{
			Handle = API.mgui_create_scrollbar( parentElement.Handle );
		}

		public Scrollbar( Element parentElement, VectorScreen absPos, VectorScreen absSize, ELEMFLAG flags, Colour col )
		{
			Handle = API.mgui_create_scrollbar_ex( parentElement.Handle, absPos.x, absPos.y, (ushort)absSize.x, (ushort)absSize.y, (uint)flags, col.AsHex() );
		}

		public void SetParameters( float content, float step, float position, float size )
		{
			API.mgui_scrollbar_set_param( Handle, content, step, position, size );
		}

		public float ContentSize
		{
			get { return API.mgui_scrollbar_get_content_size( Handle ); }
			set { API.mgui_scrollbar_set_content_size( Handle, value ); }
		}

		public float StepSize
		{
			get { return API.mgui_scrollbar_get_step_size( Handle ); }
			set { API.mgui_scrollbar_set_step_size( Handle, value ); }
		}

		public float BarPosition
		{
			get { return API.mgui_scrollbar_get_bar_pos( Handle ); }
			set { API.mgui_scrollbar_set_bar_pos( Handle, value ); }
		}

		public float BarSize
		{
			get { return API.mgui_scrollbar_get_bar_size( Handle ); }
			set { API.mgui_scrollbar_set_bar_size( Handle, value ); }
		}

		public float BackgroundShade
		{
			get { return API.mgui_scrollbar_get_bg_shade( Handle ); }
			set { API.mgui_scrollbar_set_bg_shade( Handle, value ); }
		}

		// --------------------------------------------------
		// Element flag properties
		// --------------------------------------------------

		public bool Horizontal
		{
			get { return GetFlag( ELEMFLAG.SCROLLBAR_HORIZ ); }
			set { SetFlag( ELEMFLAG.SCROLLBAR_HORIZ, value ); }
		}

		// --------------------------------------------------
		// Events
		// --------------------------------------------------

		public event ScrollEventHandler OnScroll;
	}
}
