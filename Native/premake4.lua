-- Native code for Mylly GUI C# wrapper

project "MGUI-CSharp-Native"
	kind "SharedLib"
	language "C"
	files { "*.c", "*.h", "premake4.lua", "mgui.def" }
	location ( "../Projects/" .. os.get() .. "/" .. _ACTION )
	targetname "mgui"
	targetextension ".dll"

	links {
		"Lib-Platform",
		"Lib-Types",
		"Lib-Math",
		"Lib-Stringy",
		"Lib-Input",
		"Lib-MGUI",
	}
	
	vpaths {
			[""] = { "../Native/*" }
		}

	linkoptions { "/DEF:../../../Native/mgui.def" }
	
	configuration "Debug"
		targetdir "../Builds/Debug"

	configuration "Release"
		targetdir "../Builds/Release"
