using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGUI
{
	public delegate void CursorEventHandler( object sender, CursorEventArgs e );

	public class CursorEventArgs : EventArgs
	{
		public CursorEventArgs( short _x, short _y )
		{
			x = _x;
			y = _y;
		}

		short x, y;
	}
}
