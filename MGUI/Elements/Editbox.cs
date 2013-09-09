using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGUI.Math;

namespace MGUI
{
	public class Editbox : Element
	{
		public Editbox( Element parentElement )
		{
			Handle = API.mgui_create_editbox( parentElement.Handle );
		}

		public Editbox( Element parentElement, VectorScreen absPos, VectorScreen absSize, ELEMFLAG flags, Colour col, string text )
		{
			Handle = API.mgui_create_editbox_ex( parentElement.Handle, absPos.x, absPos.y, (ushort)absSize.x, (ushort)absSize.y, (uint)flags, col.AsHex(), text );
		}
	}
}
