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
			await using (var x = new MyAsyncDisposable())
			{
				await foreach (var i in x.GetBigResultsAsync())
				{
					Console.WriteLine(i);
				}
			}
		}

		public class MyAsyncDisposable : IAsyncDisposable
		{
			public async IAsyncEnumerable<int> GetBigResultsAsync()
			{
				await foreach (var result in GetResultsAsync())
				{
					if (result > 20)
					{
						yield return result;
					}
				}
			}

			public async IAsyncEnumerable<int> GetResultsAsync()
			{
				for (int i = 0; i < 30; i++)
				{
					await Task.Delay(100);
					yield return i;
				}
			}

			public async ValueTask DisposeAsync()
			{
				await Task.Delay(200);
				Console.WriteLine("Dispose Async...");
			}
		}
	}
}
