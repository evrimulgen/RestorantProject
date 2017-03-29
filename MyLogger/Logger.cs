using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{
    public class Logger
    {
        public static void Log(string logInfo)
        {
            Debug.WriteLine(logInfo);
        }
    }

}
