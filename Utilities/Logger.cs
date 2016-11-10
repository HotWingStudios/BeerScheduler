using log4net;
using System;
using System.Diagnostics;

namespace BeerScheduler.Utilities
{
    public static class Logger
    {
        private static ILog Log4NetLogger
        {
            get
            {
                return LogManager.GetLogger("BeerScheduler");
            }
        }

        public static void Log(
            string message,
            TraceEventType severity = TraceEventType.Verbose,
            Exception exception = null)
        {
            try
            {
                switch (severity)
                {
                    case TraceEventType.Critical:
                        Log4NetLogger.Fatal(message, exception);
                        break;
                    case TraceEventType.Error:
                        Log4NetLogger.Error(message, exception);
                        break;
                    case TraceEventType.Information:
                    case TraceEventType.Verbose:
                        Log4NetLogger.Info(message);
                        break;
                    case TraceEventType.Warning:
                        Log4NetLogger.Warn(message, exception);
                        break;
                    default:
                        Log4NetLogger.Info(message, exception);
                        break;
                }
            }
            catch (Exception ex)
            {
                // Don't let logging take down the app 
                Trace.WriteLine(ex.Message);
            }
        }
    }
}
