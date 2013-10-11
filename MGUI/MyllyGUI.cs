using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MGUI
{
	public static class MyllyGUI
	{
		public static void Initialize( IntPtr wndHandle, string skin )
		{
			IntPtr rendPtr = API.mgui_create_hardware_renderer( wndHandle );
			IRenderer renderer = (IRenderer)Marshal.PtrToStructure( rendPtr, typeof(IRenderer) );

			API.mgui_initialize( wndHandle, (uint)MGUI_PARAMETERS.HOOK_INPUT | (uint)MGUI_PARAMETERS.USE_DRAW_EVENT );
			API.mgui_set_renderer( ref renderer );
			API.mgui_set_skin( skin );

			loopTimer = new Timer( 15 );
			loopTimer.Elapsed += new ElapsedEventHandler( Process );
			loopTimer.Enabled = true;
			loopTimer.Start();

			initialized = false;

			// Create a Null element which can be used as a parent
			Element.Null = new Element();
			ListboxItem.Null = new ListboxItem();
		}

		public static void Shutdown()
		{
			loopTimer.Stop();
			loopTimer.Dispose();

			API.mgui_shutdown();
		}

		private static void Process( object sender, ElapsedEventArgs e )
		{
			if ( !initialized )
			{
				initialized = true;
				return;
			}

			API.mgui_pre_process();
			API.mgui_process();
		}

		public static void Redraw()
		{
			API.mgui_force_redraw();
		}

		public static void Resize( ushort width, ushort height )
		{
			API.mgui_resize( width, height );
		}

		private static Timer loopTimer;
		private static bool initialized;
	}
}
