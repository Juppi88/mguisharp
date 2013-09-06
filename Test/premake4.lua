-- A test application for Mylly GUI C# wrapper

project "MGUI-CSharp-Test"
	kind "WindowedApp"
	language "C#"
	files { "**.cs", "**.resx", "**.settings", "**.config", "premake4.lua" }
	location ( "../Projects/" .. os.get() .. "/" .. _ACTION )
	targetextension ".exe"
	
	links {
		"System",
		"System.Core",
		"System.Data",
		"System.Drawing",
		"System.Windows.Forms",
		"MGUI CSharp"
	}

	vpaths {
			["Properties"] = { "../Test/Properties/**" },
			[""] = { "../Test/*.cs", "../Test/premake4.lua" } }

	configuration "Debug"
		targetname "guitestcs"
		targetdir "../Builds/Debug"

	configuration "Release"
		targetname "guitestcs"
		targetdir "../Builds/Release"
