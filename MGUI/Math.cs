using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MGUI
{
	namespace Math
	{
		// VectorScreen implementation
		[StructLayout( LayoutKind.Explicit )]
		public struct VectorScreen
		{
			public VectorScreen( short X, short Y ) { x = X; y = Y; }

			[FieldOffset(0)] public short x;
			[FieldOffset(2)] public short y;
		}

		// Vector2 implementation
		[StructLayout( LayoutKind.Explicit )]
		public struct Vector2
		{
			public Vector2( float X, float Y ) { x = X; y = Y; }

			[FieldOffset(0)] public float x;
			[FieldOffset(4)] public float y;
		}

		// Vector3 implementation
		[StructLayout( LayoutKind.Explicit )]
		public struct Vector3
		{
			public Vector3( float X, float Y, float Z ) { x = X; y = Y; z = Z; }

			[FieldOffset(0)] public float x;
			[FieldOffset(4)] public float y;
			[FieldOffset(8)] public float z;
		}

		// Matrix4 implementation
		[StructLayout( LayoutKind.Explicit )]
		public struct Matrix4
		{

			[FieldOffset(0)]  public Vector3 rot1;
			[FieldOffset(12)] public Vector3 rot2;
			[FieldOffset(24)] public Vector3 rot3;
			[FieldOffset(36)] public Vector3 pos;
		}

		// Colour implementation
		[StructLayout( LayoutKind.Explicit )]
		public struct Colour
		{
			public Colour( byte R, byte G, byte B ) { r = R; g = G; b = B; a = 255; }
			public Colour( byte R, byte G, byte B, byte A ) { r = R; g = G; b = B; a = A; }

			public uint AsHex() { return ( (uint)r << 24 ) | ( (uint)g << 16 ) | ( (uint)b << 8 ) | (uint)a; }

			[FieldOffset(0)] public byte a;
			[FieldOffset(1)] public byte b;
			[FieldOffset(2)] public byte g;
			[FieldOffset(3)] public byte r;
		}
	}
}
