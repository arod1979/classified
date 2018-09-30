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

        public static string server { get; set; }


        static Logger()
        {
            string filepath = System.DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            string path = String.Format("{0}{1}", "~/logfiles/", /*SPath()*/ filepath);
            //if (!Directory.Exists("~logfiles")) Directory.CreateDirectory("~logfiles");
            //if (!File.Exists("~logfiles/" + filepath)) File.Create("~logfiles/" + filepath);

            string combinedpath = Path.Combine(System.Web.HttpContext.Current.Server.
            MapPath(
                 path
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
                Logger.Write(e.ToString());
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