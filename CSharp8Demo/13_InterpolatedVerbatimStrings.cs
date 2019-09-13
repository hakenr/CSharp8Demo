using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haken.CSharp8Demo
{
	public class InterpolatedVerbatimStrings
	{
		public void Demo()
		{
			string s;

			s = "D:\\Demo"; // string
			s = @"D:\Demo"; // @ = verbatim string
			s = $"Today {DateTime.Today:g}"; // $ = interpolated string

			s = $@"C# 7 interpolated verbatim string";

			s = @$"C# 8 interpolated verbatim string";


			Console.WriteLine(s);
		}
	}
}
