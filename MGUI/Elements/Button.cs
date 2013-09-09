using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGUI.Math;

namespace MGUI
{
	public class Button : Element
	{
		public Button( Element parentElement )
		{
			elementHandle = API.mgui_create_button( parentElement.Handle );
		}

		public Button( Element parentElement, VectorScreen absPos, VectorScreen absSize, ELEMENT flags, Colour col, string text )
		{
			elementHandle = API.mgui_create_button_ex( parentElement.Handle, absPos.x, absPos.y, (ushort)absSize.x, (ushort)absSize.y, (uint)flags, col.AsHex(), text );
		}
	}
}
