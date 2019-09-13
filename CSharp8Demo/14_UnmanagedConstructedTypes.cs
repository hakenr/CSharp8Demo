using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haken.CSharp8Demo
{
	// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/unmanaged-types

	public class UnmanagedConstructedTypes
	{
		public struct Coords<T>
		{
			public T X;
			public T Y;
		}

		public static void Demo()
		{
			// the Coords<int> type is an unmanaged type in C# 8.0 and later
			// Like for any unmanaged type, you can create a pointer to a variable of this type
			// or allocate a block of memory on the stack for instances of this type:

			Span<Coords<int>> coordinates = stackalloc[]
			{
				new Coords<int> { X = 0, Y = 0 },
				new Coords<int> { X = 0, Y = 3 },
				new Coords<int> { X = 4, Y = 0 }
			};

			DisplaySize<Coords<int>>();
			DisplaySize<Coords<double>>();
		}

		private unsafe static void DisplaySize<T>()
			where T : unmanaged  // C# 7.3 - unmanaged constraints
		{
			Console.WriteLine($"{typeof(T)} is unmanaged and its size is {sizeof(T)} bytes");
		}
	}
}
