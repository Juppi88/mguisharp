-- Mylly GUI C# wrapper

solution ( "MGUI CSharp " .. string.upper( _ACTION ) )
	configurations { "Debug", "Release" }
	flags { "ExtraWarnings" }
	targetdir ( "../Builds/Lib/" .. os.get() .. "/" .. _ACTION )
	
	configuration "Release"
		defines { "NDEBUG" }
		flags { "Optimize", "FloatFast" }
	
	configuration "Debug"
		defines { "DEBUG", "_DEBUG" }
		flags { "Symbols" }
	
	-- Include the actual project file
	include "../MGUI"
	include "../Test"
	