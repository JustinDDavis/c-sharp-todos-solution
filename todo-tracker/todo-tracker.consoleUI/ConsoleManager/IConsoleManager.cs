using System;
namespace todo_tracker.consoleUI.ConsoleManager
{
	public interface IConsoleManager
	{
		void Write(string value);
		void WriteLine(string value);
		ConsoleKeyInfo ReadKey();
		string ReadLine();
		void Clear();
	}
}

