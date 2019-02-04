using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Haken.CSharp8Demo.State;
using static Haken.CSharp8Demo.Transition;

namespace Haken.CSharp8Demo
{
    public class PatternMatching
    {
		public static void Demo()
		{
			// C# 7.0
			string Display0(object o)
			{
				switch (o)
				{
					case Point p when p.X == 0 && p.Y == 0:
						return "origin";
					case Point p:
						return $"({p.X}, {p.Y})";
					default:
						return "unknown";
				}
			}
			Console.WriteLine(Display0(new Point(10, 20))); // (10, 20)


			// C# 8.0 Switch Expression
			string Display1(object o) => o switch
			{
				Point p when p.X == 0 && p.Y == 0	=> "origin",
				Point p								=> $"({p.X}, {p.Y})",
				_									=> "unknown"
			};
			Console.WriteLine(Display1(new Point(10, 20))); // (10, 20)


			// C# 8.0 Property patterns
			string Display2(object o) => o switch
			{
				Point { X: 0, Y: 0 }			=> "origin",
				Point { X: var x, Y: var y }	=> $"({x}, {y})",
				_								=> "unknown"
			};
			Console.WriteLine(Display2(new Point(10, 20))); // (10, 20)


			// C# 8.0 Property patterns II
			string Display3(object o) => o switch
			{
				Point { X: 0, Y: 0 }			=> "origin",
				Point { X: var x, Y: var y }	=> $"({x}, {y})",
				{ }								=> o.ToString(), // {} = not null
				null							=> "null"
			};
			Console.WriteLine(Display3("blah")); // blah


			// C# 8.0 Positional patterns - Deconstruction (Tuples)
			(int x, int y) = new Point(10, 10);
			string Display4(object o) => o switch
			{
				Point(0, 0)				=> "origin",
				Point(var x, var y)		=> $"({x}, {y})",
				_						=> "unknown"
			};
			Console.WriteLine(Display4(new Point(15, 10))); // (15, 10)


			// C# 8.0 Tuple patterns
			State ChangeState(State current, Transition transition, bool hasKey) =>
			(current, transition) switch
			{
				(Opened, Close) => Closed,
				(Closed, Open) => Opened,
				(Closed, Lock) when hasKey => Locked,
				(Locked, Unlock) when hasKey => Closed,
				_ => throw new InvalidOperationException($"Invalid transition")
			};
			var s = ChangeState(Opened, Close, false); // Closed


			// C# 8.0 Tuple patterns - more readable?
			State ChangeState2(State current, Transition transition, bool hasKey) =>
			(current, transition, hasKey) switch
			{
				(Opened, Close, _)		=> Closed,
				(Closed, Open, _)		=> Opened,
				(Closed, Lock, true)	=> Locked,
				(Locked, Unlock, true)	=> Closed,
				_ => throw new InvalidOperationException($"Invalid transition")
			};
			var s2 = ChangeState2(Closed, Lock, true); // Locked


			// C# 8.0 Recursive Patterns - allowing patterns to contain other patterns (1: is Point, 2: X == 0)
			object p = new Point(0, 20);
			if (p is Point { X: 0, Y: var pY })
			{
				Console.WriteLine(pY);
			}
		}
	}

	public static class PointExtensions
	{
		public static void Deconstruct(this Point p, out int x, out int y)
		{
			x = p.X;
			y = p.Y;
		}
	}

	public enum State
	{
		Opened,
		Closed,
		Locked
	}

	public enum Transition
	{
		Close,
		Open,
		Lock,
		Unlock
	}
}
