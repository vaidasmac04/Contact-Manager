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
    public class ContactsRetriever
    {
        public IList<Contact> RetrieveContacts()
        {
            IList<Contact> contacts = new List<Contact>();

            if (File.Exists(FilePathGetter.GetContactsFilePath()))
            {
                using (StreamReader file = new StreamReader(FilePathGetter.GetContactsFilePath()))
                {
                    string line;

                    //id's are renewed for every contact while reading from file
                    int id = 0;
                    while ((line = file.ReadLine()) != null)
                    {
                        Contact contact = ConvertJsonToContact(line);
                        contact.Id = ++id;
                        contacts.Add(contact);
                    }
                    file.Close();

                    Contact.LastId = id;
                }
            }

            return contacts;
        }

        private Contact ConvertJsonToContact(string json)
        {
             return JsonConvert.DeserializeObject<Contact>(json);
        }
    }
}
