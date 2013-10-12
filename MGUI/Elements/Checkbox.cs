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

		// --------------------------------------------------
		// Element flag properties
		// --------------------------------------------------

		public bool Selected
		{
			get { return GetFlag( ELEMFLAG.CHECKBOX_CHECKED ); }
			set { SetFlag( ELEMFLAG.CHECKBOX_CHECKED, value ); }
		}

		// --------------------------------------------------
		// Events
		// --------------------------------------------------

		public event EventHandler OnToggle;
	}
}
