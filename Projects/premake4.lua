-- Mylly GUI C# wrapper

solution ( "MGUI CSharp " .. string.upper( _ACTION ) )
	configurations { "Debug", "Release" }
	flags { "ExtraWarnings" }
	targetdir ( "../Builds/Lib/" .. os.get() .. "/" .. _ACTION )
	includedirs { "../Libraries", "../Libraries/Types" }
	libdirs { "../Builds/Lib/" }
	defines { "MYLLY_SHARED_LIB" }
	
	configuration "Release"
		defines { "NDEBUG" }
		flags { "Optimize", "FloatFast" }
	
	configuration "Debug"
		defines { "DEBUG", "_DEBUG" }
		flags { "Symbols" }
	
	-- Include the project files
	include "../MGUI"
	include "../Test"
	
	include "../Native"
	
	-- Include libraries
	include "../Libraries/Input"
	include "../Libraries/Math"
	include "../Libraries/MGUI"
	include "../Libraries/MGUI/Renderer/DirectX9"
	include "../Libraries/Platform"
	include "../Libraries/Stringy"
	include "../Libraries/Types"
