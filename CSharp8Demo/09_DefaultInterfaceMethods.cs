using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haken.CSharp8Demo
{
	public class DefaultInterfaceMethods
	{
		interface ILogger
		{
			void Log(LogLevel level, string message);
			void Log(Exception ex) => Log(LogLevel.Error, "ILogger:" + ex.ToString()); // New overload
		}

		public class ConsoleLogger : ILogger
		{
			public void Log(LogLevel level, string message) { Console.WriteLine(message); }
			// ConsoleLogger gets Log(Exception) default implementation
		}

		public class AnotherLogger : ILogger
		{
			public void Log(LogLevel level, string message) { }
			public void Log(Exception ex) => Console.WriteLine("AnotherLogger:" + ex.ToString());
		}

		public enum LogLevel
		{
			Info,
			Error
		}

		public static void Demo()
		{
			// won't compile: new ConsoleLogger().Log(new Exception("Test"));

			((ILogger)new ConsoleLogger()).Log(new Exception("Test1"));    // ILogger:System.Exception: Test1

			new AnotherLogger().Log(new Exception("Test3"));               // AnotherLogger:System.Exception: Test3

			((ILogger)new AnotherLogger()).Log(new Exception("Test2"));    // AnotherLogger:System.Exception: Test3

			ILogger logger = new AnotherLogger();                          
			logger.Log(new Exception("Test4"));                            // AnotherLogger:System.Exception: Test4
		}
	}
}
