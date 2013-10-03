using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGUI.Math;

namespace MGUI
{
	public partial class Checkbox : Element
	{
		public Checkbox( Element parentElement )
		{
			Handle = API.mgui_create_checkbox( parentElement.Handle );
		}

		public Checkbox( Element parentElement, VectorScreen absPos, ELEMFLAG flags, Colour col )
		{
			Handle = API.mgui_create_checkbox_ex( parentElement.Handle, absPos.x, absPos.y, (uint)flags, col.AsHex() );
		}

		public bool Selected
		{
			get { return ( ( API.mgui_get_flags( Handle ) & (uint)ELEMFLAG.CHECKBOX_CHECKED ) != 0 ); }
			set
			{
				if ( value )
					API.mgui_add_flags( Handle, (uint)ELEMFLAG.CHECKBOX_CHECKED );
				else
					API.mgui_remove_flags( Handle, (uint)ELEMFLAG.CHECKBOX_CHECKED );
			}
		}

		public event EventHandler OnToggle;
	}
}
