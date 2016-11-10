using System;
using System.Diagnostics;
using System.Text;
using log4net.Config;

namespace BeerScheduler.Web
{
    public class LifecycleManagement
    {
        public static void AppInitialize()
        {
            XmlConfigurator.Configure();
#if DEBUG
            Console.SetOut(new DebugTextWriter());
#endif
        }

#if DEBUG
        private class DebugTextWriter : System.IO.TextWriter
        {
            public override void Write(char[] buffer, int index, int count)
            {
                System.Diagnostics.Debug.Write(new String(buffer, index, count));
            }

            public override void Write(string value)
            {
                System.Diagnostics.Debug.Write(value);
            }

            public override Encoding Encoding
            {
                get { return System.Text.Encoding.Default; }
            }
        }
#endif
    }
}