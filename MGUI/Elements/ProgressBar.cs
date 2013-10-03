using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGUI.Math;

namespace MGUI
{
	public class ProgressBar : Element
	{
		public ProgressBar( Element parentElement )
		{
			Handle = API.mgui_create_progressbar( parentElement.Handle );
		}

		public ProgressBar( Element parentElement, VectorScreen absPos, VectorScreen absSize, ELEMFLAG flags, Colour colStart, Colour colEnd, float maxValue )
		{
			Handle = API.mgui_create_progressbar_ex( parentElement.Handle, absPos.x, absPos.y, (ushort)absSize.x, (ushort)absSize.y, (uint)flags, colStart.AsHex(), colEnd.AsHex(), maxValue );
		}

		public float Value
		{
			get { return API.mgui_progressbar_get_value( Handle ); }
			set { API.mgui_progressbar_set_value( Handle, value ); }
		}

		public float MaxValue
		{
			get { return API.mgui_progressbar_get_max_value( Handle ); }
			set { API.mgui_progressbar_set_max_value( Handle, value ); }
		}

		public float BackgroundShade
		{
			get { return API.mgui_progressbar_get_bg_shade( Handle ); }
			set { API.mgui_progressbar_set_bg_shade( Handle, value ); }
		}

		public byte Thickness
		{
			get { return API.mgui_progressbar_get_thickness( Handle ); }
			set { API.mgui_progressbar_set_thickness( Handle, value ); }
		}

		public void GetColours( out Colour colStart, out Colour colEnd )
		{
			API.mgui_progressbar_get_colour( Handle, out colStart, out colEnd );
		}

		public void SetColours( ref Colour colStart, ref Colour colEnd )
		{
			API.mgui_progressbar_set_colour( Handle, ref colStart, ref colEnd );
		}
	}
}
