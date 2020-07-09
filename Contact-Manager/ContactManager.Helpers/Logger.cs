using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.ContactManger.Helpers
{
    public class Logger
    {
        public static void Log(String message)
        {
            using (StreamWriter file = new StreamWriter(FilePathGetter.GetLogFilePath(), true))
            {
                file.WriteLine(message + " at " + DateTime.Now);
            }
        }
    }
}
