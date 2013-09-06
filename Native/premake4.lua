-- Native code for Mylly GUI C# wrapper

project "MGUI-CSharp-Native"
	kind "SharedLib"
	language "C"
	files { "*.c", "*.h", "premake4.lua" }
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

	configuration "Debug"
		targetdir "../Builds/Debug"

	configuration "Release"
		targetdir "../Builds/Release"
