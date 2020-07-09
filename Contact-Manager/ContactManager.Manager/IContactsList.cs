using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.ContactManager.Manager
{
    public interface IContactsList
    {
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
        IList<Contact> GetContacts();
    }
}
