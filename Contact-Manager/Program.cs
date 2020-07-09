using ContactManager.ContactManager.Manager;
using ContactManager.ContactManager.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            UserHandler userHandler = new UserHandler(new ContactsList(), new ContactsSaver());
            userHandler.ShowConsoleWithOptions();
        }
    }
}
