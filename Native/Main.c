#define WIN32_LEAN_AND_MEAN
#include <Windows.h>

BOOL WINAPI DllMain( HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved )
{
	(void)hinstDLL;
	(void)fdwReason;
	(void)lpvReserved;

	return TRUE;
}
