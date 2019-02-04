using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VS2019Demo
{
    public class RegexParser
    {
		public static void Demo()
		{
			var regex = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");


			var regex2 = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"); // to test
		}
	}
}
