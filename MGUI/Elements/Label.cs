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
			Handle = API.mgui_create_label( parentElement.Handle );
		}

		public Label( Element parentElement, VectorScreen absPos, ELEMFLAG flags, Colour col, string text )
		{
			Handle = API.mgui_create_label_ex( parentElement.Handle, absPos.x, absPos.y, (uint)flags, col.AsHex(), text );
		}

		public void MakeTextFit()
		{
			API.mgui_label_make_text_fit( Handle );
		}
	}
}
