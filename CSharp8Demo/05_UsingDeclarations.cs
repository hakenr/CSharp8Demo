using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Haken.CSharp8Demo
{
    public class UsingDeclarations
    {
		public static void Demo()
		{
			// pre-C# 8.0
			using (var transactionScope = new TransactionScope())
			{
				// ..
				using (var conn = new SqlConnection())
				{
					// ..
					using (var command = new SqlCommand(conn, "SELECT ..."))
					{
						// ..
						using (var reader = command.ExecuteReader())
						{
							// ...
						} // reader.Dispose()
					} // command.Dispose()
				} // conn.Dispose()
				transactionScope.Complete();
			} // transactionScope.Dispose();


			Console.WriteLine("\nC# 8.0 Using Declarations:");
			for (int i = 0; i < 2; i++)
			{
				using var transactionScope2 = new TransactionScope();
				using var conn2 = new SqlConnection();
				using var command2 = new SqlCommand(conn2, "SELECT ...");
				using var reader2 = command2.ExecuteReader();
				// ...
				transactionScope2.Complete();
			} // disposes all at the end of the current statement block


			using var conn3 = new SqlConnection();
		} // conn3 disposed at the end of method
	}














	internal class SqlCommand : IDisposable
	{
		public SqlCommand(SqlConnection conn, string v)
		{
		}

		public void Dispose()
		{
			Console.WriteLine("SqlCommand Disposed.");
		}

		internal IDisposable ExecuteReader()
		{
			return new SqlDataReader();
		}
	}

	internal class SqlDataReader : IDisposable
	{
		public void Dispose()
		{
			Console.WriteLine("SqlDataReader Disposed.");
		}
	}

	internal class SqlConnection : IDisposable
	{
		public void Dispose()
		{
			Console.WriteLine("SqlConnection Disposed.");
		}
	}
}
