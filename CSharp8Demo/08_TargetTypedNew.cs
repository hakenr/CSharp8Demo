using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Haken.CSharp8Demo
{
	public class TargetTypedNew
	{
		public static void Demo()
		{
			// pre-C# 8.0
			using (var reader = XmlReader.Create("https://knowledge-base.havit.eu/feed/", new XmlReaderSettings() { IgnoreWhitespace = true })) { }

			// C# 8.0 - Not released in Preview yet
			// using var reader2 = XmlReader.Create("https://knowledge-base.havit.eu/feed/", new() { IgnoreWhitespace = true });

			// Point[] ps = { new (1, 4), new (3,-2), new (9, 5) };
			// List<string> list = new (10);
		}
	}
}
