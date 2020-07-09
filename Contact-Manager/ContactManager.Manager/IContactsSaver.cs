using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.ContactManager.Manager
{
    public interface IContactsSaver
    {
        void SaveContacts(IList<Contact> contacts);
    }
}
