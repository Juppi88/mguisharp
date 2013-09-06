using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGUI
{
	public static class MyllyGUI
	{
		public static void Initialize( IntPtr wndHandle, IRendererHandle renderer )
		{
			API.mgui_initialize( wndHandle, 0 );
			API.mgui_set_renderer( ref renderer );
			API.mgui_set_skin( null );
		}

		public static void Shutdown()
		{
			API.mgui_shutdown();
		}

		public static void Process()
		{
			API.mgui_process();
		}
	}
}
