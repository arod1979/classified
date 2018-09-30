using RegistrationPractice.Classes.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationPractice.Classes
{
    public class LoggerWrapper
    {
        public bool testingmode { get; set; }

        


        public void PickAndExecuteLogging(string message)
        {
            if (!testingmode)
            {
                Logger.Write(message);
            }
        }

    }
}