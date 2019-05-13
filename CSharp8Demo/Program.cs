using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Haken.CSharp8Demo
{
    class Program
    {
        async static Task Main(string[] args)
        {
			Console.WriteLine("\n=== IndicesAndRanges ===");
			IndicesAndRanges.Demo();

			Console.WriteLine("\n=== SwitchExpressions ===");
			SwitchExpressions.Demo();

			Console.WriteLine("\n=== PatternMatching ===");
			PatternMatching.Demo();

			Console.WriteLine("\n=== StaticLocalFunctions ===");
			StaticLocalFunctions.Demo();

			Console.WriteLine("\n=== UsingDeclarations ===");
			UsingDeclarations.Demo();

			Console.WriteLine("\n=== AsyncStreams ===");
			await AsyncStreams.Demo();

			Console.WriteLine("\n=== TargetTypedNew ===");
			TargetTypedNew.Demo();

			Console.WriteLine("\n=== NullCoallescingAssignment ===");
			NullCoallescingAssignment.Demo();

			Console.WriteLine("\n=== DefaultInterfaceMethods ===");
			DefaultInterfaceMethods.Demo();
		}
    }
}
