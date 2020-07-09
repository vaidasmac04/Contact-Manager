using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.ContactManger.Helpers
{
    public class FilePathGetter
    {
        public static string GetContactsFilePath()
        {
             return Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\" + Constants.ContactsFileName;
        }

        public static string GetLogFilePath()
        {
            return Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\" + Constants.LogFileName;
        }
    }
}
