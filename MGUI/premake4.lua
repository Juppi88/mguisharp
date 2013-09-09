-- Mylly GUI C# wrapper

project "MGUI-CSharp"
	kind "SharedLib"
	language "C#"
	files { "**.cs", "premake4.lua" }
	location ( "../Projects/" .. os.get() .. "/" .. _ACTION )
	targetextension ".dll"

	vpaths {
			["Elements"] = { "../MGUI/Elements/**" },
			["Internal"] = { "../MGUI/Internal/**" },
			[""] = { "../MGUI/*.cs", "../MGUI/premake4.lua" } }

	configuration "Debug"
		targetname "mguics"
		targetdir "../Builds/Debug"

	configuration "Release"
		targetname "mguics"
		targetdir "../Builds/Release"
