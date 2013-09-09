using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGUI.Math;

namespace MGUI
{
	public class Memobox : Element
	{
		public Memobox( Element parentElement )
		{
			Handle = API.mgui_create_memobox( parentElement.Handle );
		}

		public Memobox( Element parentElement, VectorScreen absPos, VectorScreen absSize, ELEMFLAG flags, Colour col )
		{
			Handle = API.mgui_create_memobox_ex( parentElement.Handle, absPos.x, absPos.y, (ushort)absSize.x, (ushort)absSize.y, (uint)flags, col.AsHex() );
		}

		public void AddLine( string text )
		{
			API.mgui_memobox_add_line_s( Handle, text );
		}

		public void AddColouredLine( string text, Colour col )
		{
			API.mgui_memobox_add_line_col_s( Handle, text, ref col );
		}
	}
}
