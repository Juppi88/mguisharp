using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGUI.Math;

namespace MGUI
{
	public class Label : Element
	{
		public Label( Element parentElement )
		{
			elementHandle = API.mgui_create_label( parentElement.Handle );
		}

		public Label( Element parentElement, VectorScreen absPos, VectorScreen absSize, ELEMENT flags, Colour col, string text )
		{
			elementHandle = API.mgui_create_label_ex( parentElement.Handle, absPos.x, absPos.y, (ushort)absSize.x, (ushort)absSize.y, (uint)flags, col.AsHex(), text );
		}

		public void MakeTextFit()
		{
			API.mgui_label_make_text_fit( elementHandle );
		}
	}
}
