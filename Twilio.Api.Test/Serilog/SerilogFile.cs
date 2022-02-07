using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Twilio.Api.Test.Interfaces;

namespace Twilio.Api.Test.Serilog
{
    public class SerilogFile : Interfaces.ILogger
    {
        public Logger log = new LoggerConfiguration().WriteTo.File($@"C:\Log(s)\TwilioAPI\TwilioAPI-{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.log").CreateLogger();

        public void LogIt(string logMessage)
        {
            log.Information(logMessage);
        }
    }
}
