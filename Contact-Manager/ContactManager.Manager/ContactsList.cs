using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.ContactManager.Manager
{
    public class ContactsList : IContactsList
    {
        private IList<Contact> contacts;
        private ContactsRetriever contactsRetriever;

        public ContactsList()
        {
            contactsRetriever = new ContactsRetriever();
            LoadContacts();
        }

        public void AddContact(Contact contact)
        {
            if (!CheckPhoneNumberConstraint(contact))
            {
                throw new ArgumentException("Phone number is already taken.");
            }

            contacts.Add(contact);

            contact.Id = Contact.LastId + 1;
            Contact.LastId++;
        }

        public void DeleteContact(int id)
        {
            bool found = false;

            foreach (Contact c in contacts)
            {
                if (c.Id == id)
                {
                    contacts.Remove(c);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                throw new ArgumentException("Contact with id " + id + " does not exist");
            }
        }

        public void UpdateContact(Contact contact)
        {
            foreach(Contact c in contacts)
            {
                if(c.Id == contact.Id)
                {
                    c.Name = contact.Name;
                    c.LastName = contact.LastName;

                    if (!CheckPhoneNumberConstraint(contact))
                    {
                        throw new ArgumentException("Update failed: phone number is already taken.");
                    }

                    c.PhoneNumber = contact.PhoneNumber;
                    break;
                }
            }
        }

        public IList<Contact> GetContacts()
        {
            return contacts;
        }
        
        private void LoadContacts()
        {
            contacts = contactsRetriever.RetrieveContacts();
        }

        private bool CheckPhoneNumberConstraint(Contact contact)
        {
            //id's have to be different othervise contact update would fail everytime when phone number is not changed
            if(contacts.Where(c => c.PhoneNumber == contact.PhoneNumber && c.Id != contact.Id).Any())
            {
                return false;
            }
            

            return true;
        }
    }
}
