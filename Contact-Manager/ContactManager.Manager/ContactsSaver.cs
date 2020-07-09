using ContactManager.ContactManger.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.ContactManager.Manager
{
    public class ContactsSaver : IContactsSaver
    {
        public void SaveContacts(IList<Contact> contacts)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(FilePathGetter.GetContactsFilePath(), false))
                {
                    foreach (Contact contact in contacts)
                    {
                        file.WriteLine(JsonConvert.SerializeObject(contact));
                    }
                }
            }
            catch (IOException iOException)
            {
                ExceptionHandler.PrintMessageToConsole(iOException);
            }
        }
    }
}
