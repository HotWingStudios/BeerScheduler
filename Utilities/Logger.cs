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
                return LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            }
        }

        /// <summary>
        /// Log a message to the configured logging append with an optional level and optional exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="severity">Severity.  Critical -> Fatal, Error -> Error, Information/Verbose -> Info, Warning -> Warn, (default) -> Info</param>
        /// <param name="exception"></param>
        public static void Log(
            string message,
            TraceEventType severity = TraceEventType.Verbose,
            Exception exception = null)
        {
            ////     Fatal error or application crash.        //Critical = 1,
            ////     Recoverable error.                       //Error = 2,
            ////     Noncritical problem.                     //Warning = 4,
            ////     Informational message.                   //Information = 8,
            ////     Debugging trace.                         //Verbose = 16,
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
                        Log4NetLogger.Info(message, exception);
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
