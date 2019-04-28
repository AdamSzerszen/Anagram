using System;
using System.Diagnostics;

namespace Anagram.Infrastructure.Structures
{
    public static class Logger
    {
        public static void Log(string message)
        {
            Trace.TraceInformation($"{DateTime.Now} {message}");
        }

        public static void Flush()
        {
            Trace.Flush();
        }
    }
}