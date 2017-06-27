using System;
using Microsoft.Build.Framework;

namespace IgniteCSharp.Utils
{
    public class BaseLogger : ILogger
    {
        /// <summary>
        /// Creates a logger with a name (the name will close each line)
        /// </summary>
        /// <param name="name"></param>
        public BaseLogger(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void Initialize(IEventSource eventSource) {}

        public void Shutdown() {}

        public LoggerVerbosity Verbosity { get; set; }
        public string Parameters { get; set; }

        // tags before the logs lines
        public const string InfoTag = "[INFO ] ";
        public const string WarnTag = "[WARN ] ";
        public const string ErrorTag = "[ERROR] ";
        public const string FatalTag = "[FATAL] ";

        public void Info(string message, params object[] args)
        {
            Console.WriteLine(CraftLine(message, InfoTag), args);
        }

        public void Warn(string message, params object[] args)
        {
            Console.WriteLine(CraftLine(message, WarnTag), args);
        }

        public void Error(string message, params object[] args)
        {
            Console.WriteLine(CraftLine(message, ErrorTag), args);
        }

        public void Fatal(string message, params object[] args)
        {
            Console.WriteLine(CraftLine(message, FatalTag), args);
        }

        private string CraftLine(string message, string tag)
        {
            var currentDate = DateTime.Now;
            return currentDate.ToString("yyyy-MM-dd HH:mm:ss") + " " +
                   tag + " " +
                   message + " " +
                   "[" + Name + "]";
        }
    }
}
