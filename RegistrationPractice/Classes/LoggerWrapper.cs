using RegistrationPractice.Classes.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationPractice.Classes
{
    public class LoggerWrapper
    {
        private bool testingmode { get; set; }

        public LoggerWrapper(bool testing = false)
        {
            this.testingmode = testing;
        }


        public void PickAndExecuteLogging(string message)
        {
            if (!testingmode)
            {
                Logger.Write(message);
            }
        }

    }
}