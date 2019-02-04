using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haken.CSharp8Demo
{
	public class DefaultInterfaceMethods
	{
		// Not released in Preview yet.
	}

	interface ILogger
	{
		void Log(LogLevel level, string message);
		// public void Log(Exception ex) => Log(LogLevel.Error, ex.ToString()); // New overload
	}

	public class ConsoleLogger : ILogger
	{
		public void Log(LogLevel level, string message) {  }
		// Log(Exception) gets default implementation
	}

	public enum LogLevel
	{
		Info,
		Error
	}
}
