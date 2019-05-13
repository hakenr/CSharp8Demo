using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS2019Demo
{
	public class Refactorings_TupleToStruct
	{
		// cursor position :-)
		// ___vv______________
		public (int x, int y) GetCoordinates()
		{
			return (1, 1);
		}
	}
}
