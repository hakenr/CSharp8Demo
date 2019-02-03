using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haken.CSharp8Demo
{
    public class AsyncStreams
    {
		public async static Task Demo()
		{
			await foreach (var i in GetBigResultsAsync())
			{
				Console.WriteLine(i);
			}
		}

		public static async IAsyncEnumerable<int> GetBigResultsAsync()
		{
			await foreach (var result in GetResultsAsync())
			{
				if (result > 20)
				{
					yield return result;
				}
			}
		}

		public static async IAsyncEnumerable<int> GetResultsAsync()
		{
			for (int i = 0; i < 30; i++)
			{
				await Task.Delay(100);
				yield return i;
			}
		}
	}
}
