using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGUI
{
	public delegate void CursorEventHandler( object sender, CursorEventArgs e );
	public delegate void ResizeEventHandler( object sender, ResizeEventArgs e );

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
}
