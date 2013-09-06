using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGUI.Math;

namespace MGUI
{
    public class Element
    {
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

		public IntPtr ApiHandle
		{
			get { return elementHandle; }
		}

		protected IntPtr elementHandle;
    }
}
