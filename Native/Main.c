#define WIN32_LEAN_AND_MEAN
#include <Windows.h>
#include "MGUI/MGUI.h"
#include "MGUI/Renderer/DirectX9/DirectX9.h"

BOOL WINAPI DllMain( HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved )
{
	(void)hinstDLL;
	(void)fdwReason;
	(void)lpvReserved;

	return TRUE;
}

MGuiRenderer* mgui_create_hardware_renderer( HWND hwnd )
{
	return mgui_directx9_initialize( hwnd );
}

void mgui_destroy_hardware_renderer( void )
{
	mgui_directx9_shutdown();
}
