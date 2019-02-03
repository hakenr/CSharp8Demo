using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haken.CSharp8Demo
{
    public class StaticLocalFunctions
    {
		public static void Demo()
		{
			static void DoSomething(object x)
			{
				Console.WriteLine(x.ToString());
			}

			DoSomething("Calling static local function...");
		}
    }
}
