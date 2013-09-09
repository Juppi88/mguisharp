using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGUI.Math;

namespace MGUI
{
	public class Canvas : Element
	{
		public Canvas( Element parentElement )
		{
			Handle = API.mgui_create_canvas( parentElement.Handle );
		}
	}
}
