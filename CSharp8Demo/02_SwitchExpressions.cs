using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haken.CSharp8Demo
{
    public class SwitchExpressions
    {
        public static void Demo()
		{
			var i = 10;

			// basic syntax
			var x = i switch // infix
			{
				1 => "one",
				2 => "two",
				3 => "three",
				_ => "many"  // discard = default
			};
			Console.WriteLine(x);


			// supports pattern matching
			string Display(object o) => o switch   // BTW local function (C# 7.0)
			{
				Point p when (p.X == 0) && (p.Y == 0)	=> "origin",
				Point p									=> $"({p.X}, {p.Y})",
				_										=> "unknown"
			};
			Console.WriteLine(Display(new Point(0, 0))); // origin


			// same in C# 7.0 - switch statement
			string DisplayOld(object o)
			{
				switch (o)
				{
					case Point p when (p.X == 0) && (p.Y == 0):
						return "origin";
					case Point p:
						return $"({p.X}, {p.Y})";
					default:
						return "unknown";
				}
			}
			Console.WriteLine(DisplayOld(new Point(0, 0))); // origin

			// for further improvements see 03_PatternMatching.cs
		}
	}
}
