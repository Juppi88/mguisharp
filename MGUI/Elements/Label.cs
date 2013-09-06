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
		public Label()
		{
			elementHandle = API.mgui_create_label( null );
		}

		public Label( ref Element parentElement )
		{
			elementHandle = API.mgui_create_label( parentElement.ApiHandle );
		}

		public Label( ref Element parentElement, ref VectorScreen absPos, ref VectorScreen absSize, uint flags, ref Colour col, string text )
		{
			elementHandle = API.mgui_create_label_ex( parentElement.ApiHandle, absPos.x, absPos.y, (ushort)absSize.x, (ushort)absSize.y, flags, col.AsHex(), text );
		}

		public void MakeTextFit()
		{
			API.mgui_label_make_text_fit( elementHandle );
		}
	}
}
