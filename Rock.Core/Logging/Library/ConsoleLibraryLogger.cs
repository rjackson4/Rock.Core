﻿using System;
using Rock.StringFormatting;

namespace Rock.Logging.Library
{
    /// <summary>
    /// An implementation of <see cref="ILibraryLogger"/> that records log messages with
    /// the <see cref="Console"/> class.
    /// </summary>
    public class ConsoleLibraryLogger : ILibraryLogger
    {
        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Log(ILibraryLogMessage message)
        {
            Console.Write("LOG");
            WriteMessage(message);
        }

        /// <summary>
        /// Logs the specified debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(ILibraryLogMessage message)
        {
            Console.Write("DEBUG");
            WriteMessage(message);
        }

        private static void WriteMessage(ILibraryLogMessage message)
        {
            Console.WriteLine(" {0:O} {1}", message.CreateTime, message.LibraryName);
            Console.WriteLine("    {0}", message.Message);
            Console.WriteLine("    {0}:{1}({2})", message.CallerFilePath, message.CallerMemberName, message.CallerLineNumber);

            if (message.Exception != null)
            {
                Console.WriteLine(message.Exception.FormatToString());
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}