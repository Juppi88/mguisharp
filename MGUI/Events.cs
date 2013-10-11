using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGUI
{
	public delegate void CursorEventHandler( object sender, CursorEventArgs e );
	public delegate void ResizeEventHandler( object sender, ResizeEventArgs e );
	public delegate void ListEventHandler( object sender, ListEventArgs e );
	public delegate void ScrollEventHandler( object sender, ScrollEventArgs e );

	public class CursorEventArgs : EventArgs
	{
		public CursorEventArgs( short x, short y )
		{
			X = x;
			Y = y;
		}

		short X, Y;
	}

	public class ResizeEventArgs : EventArgs
	{
		public ResizeEventArgs( ushort width, ushort height )
		{
			Width = width;
			Height = height;
		}

		ushort Width, Height;
	}

	public class ListEventArgs : EventArgs
	{
		public ListEventArgs( ListboxItem item )
		{
			Selected = item;
		}

		ListboxItem Selected;
	}

	public class ScrollEventArgs : EventArgs
	{
		public ScrollEventArgs( float pos, float change )
		{
			Position = pos;
			Change = change;
		}

		float Position, Change;
	}
}
