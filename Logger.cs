using System;
using System.IO;

namespace GameLibraryManager
{
    public class Logger
    {
        private const string LogFile = "application.log";

        public void Log(string message)
        {
            string logEntry = $"[LOG] {DateTime.Now}: {message}";
            Console.WriteLine(logEntry);
            File.AppendAllText(LogFile, logEntry + Environment.NewLine);
        }
    }
}
