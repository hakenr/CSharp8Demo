using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Haken.CSharp8Demo
{
    class Program
    {
        async static Task Main(string[] args)
        {
			//IndicesAndRanges.Demo();
			SwitchExpressions.Demo();
			PatternMatching.Demo();
			StaticLocalFunctions.Demo();
			UsingDeclarations.Demo();
			await AsyncStreams.Demo();
			TargetTypedNew.Demo();
			NullCoallescingAssignment.Demo();
		}
    }
}
