using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGUI
{
	public static class MyllyGUI
	{
		public static void Initialize( IntPtr wndHandle, ref IRenderer renderer )
		{
			API.mgui_initialize( wndHandle, (uint)MGUI_PARAMETERS.HOOK_INPUT | (uint)MGUI_PARAMETERS.USE_DRAW_EVENT );
			API.mgui_set_renderer( ref renderer );
			API.mgui_set_skin( null );

			// Create a Null element which can be used as a parent
			Element.Null = new Element();
		}

		public static void Shutdown()
		{
			API.mgui_shutdown();
		}

		public static void Process()
		{
			API.mgui_process();
		}

		public static void Redraw()
		{
			API.mgui_force_redraw();
		}
	}
}
