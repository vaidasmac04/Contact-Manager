using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.ContactManger.Helpers
{
    public static class ExceptionHandler
    {
        public static void PrintMessageToConsole(Exception exception)
        {
            Console.WriteLine("--> " + exception.Message);
        }
    }
}
