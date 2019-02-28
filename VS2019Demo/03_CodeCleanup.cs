using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS2019Demo
{
	// CLI alternative (new global tool): dotnet.exe format 
	public class CodeCleanup 
    {
		int x;
		object y;

		public CodeCleanup(object y)
		{
			this.y = y;
		}

		public static void Demo() {

			int[] a = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			foreach (var i in Enumerable.Range(1, 10)) {
				Console.Write(i);
			}
			Console.WriteLine();


			foreach (var i in Enumerable.Range(1, 10))
				Console.Write(i);
		}
	}
}
