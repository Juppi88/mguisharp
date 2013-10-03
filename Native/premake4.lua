-- Native code for Mylly GUI C# wrapper

project "MGUI-CSharp-Native"
	kind "SharedLib"
	language "C"
	files { "*.c", "*.h", "premake4.lua", "mgui.def" }
	location ( "../Projects/" .. os.get() .. "/" .. _ACTION )
	targetname "mgui"
	targetextension ".dll"
	buildoptions { "/wd4201 /wd4996" } -- C4201: nameless struct/union, C4996: This function or variable may be unsafe.

	links {
		"Lib-Platform",
		"Lib-Types",
		"Lib-Math",
		"Lib-Stringy",
		"Lib-Input",
		"Lib-MGUI",
		"Lib-MGUI-Renderer-DirectX9",
		"d3d9",
		"d3dx9"
	}
	
	vpaths {
			[""] = { "../Native/*" }
		}

	linkoptions { "/DEF:../../../Native/mgui.def" }
	
	configuration "Debug"
		targetdir "../Builds/Debug"

	configuration "Release"
		targetdir "../Builds/Release"
