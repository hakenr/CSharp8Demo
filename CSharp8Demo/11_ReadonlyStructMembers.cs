using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haken.CSharp8Demo
{
	// prior to C# 8, only whole struct could be marked as readonly (C# 7.2) or the field-members
	public struct MyPoint
    {
		public double X { get; set; }
		public double Y { get; set; }

		public /* readonly */ double Distance => Math.Sqrt(X * X + Y * Y);

		// creates defensive copy of 'this' if the Distance is not marked as read-only
		public readonly override string ToString() =>
			$"({X}, {Y}) is {Distance} from the origin";

		public /* readonly */ void Translate(int xOffset, int yOffset)
		{
			X += xOffset;
			Y += yOffset;
		}
	}
}
