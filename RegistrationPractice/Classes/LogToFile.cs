using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace RegistrationPractice.Classes.Loggers
{
    public static class Logger
    {
        static readonly TextWriter tw;

        private static readonly object _syncObject = new object();

        public static object ConfigManager { get; private set; }

        static Logger()
        {

            //tw = TextWriter.Synchronized(File.AppendText(SPath() + "\\Log.txt"));

            string combinedpath = Path.Combine(System.Web.HttpContext.Current.Server.
            MapPath(
            String.Format("{0}{1}", "~/logfiles", SPath())
            )
            );
            tw = TextWriter.Synchronized(File.AppendText(combinedpath));
        }

        public static string SPath()
        {
            return ConfigurationManager.AppSettings["loggerpath"].ToString();
        }

        public static void Write(string logMessage)
        {
            try
            {
                Log(logMessage, tw);
            }
            catch (IOException e)
            {
                tw.Close();
            }
        }

        public static void Log(string logMessage, TextWriter w)
        {

            lock (_syncObject)
            {
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", logMessage);
                w.WriteLine("-------------------------------");

                // Update the underlying file.
                w.Flush();
            }
        }
    }
}