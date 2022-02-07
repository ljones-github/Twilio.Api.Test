using Serilog;
using Serilog.Core;
using Serilog.Sinks.Debug;
using System;
using System.Collections.Generic;
using System.Text;
using Twilio.Api.Test.Interfaces;

namespace Twilio.Api.Test
{
    public class SerilogConsole : Interfaces.ILogger
    {
        public Logger log = new LoggerConfiguration().WriteTo.Debug().CreateLogger();

        public void LogIt(string logMessage)
        {
            {
                Console.WriteLine(logMessage);
            }
        }
    }
}