using ContactManager.ContactManager.Manager;
using ContactManager.ContactManger.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.ContactManager.UI
{
    public class ContactsListUI
    {
        public void ShowContacts(IList<Contact> contacts)
        {
            if (contacts.Any())
            {
                Console.WriteLine(String.Format("{0,-4} {1,-25} {2,-25} {3, -15} {4, -40}", "Id", "Name", "LastName", "PhoneNumber", "Address"));
                foreach (Contact contact in contacts)
                {
                    Console.WriteLine(contact.ToString());
                }
            }
            else
            {
                Console.WriteLine("There are no contacts!");
            }
        }

        public Contact AddContact()
        {
            Contact contact = new Contact();

            Console.Write("--> Please enter name: ");
            contact.Name = Console.ReadLine();

            Console.Write("--> Please enter last name: ");
            contact.LastName = Console.ReadLine();

            Console.Write("--> Please enter phone number: ");
            contact.PhoneNumber = Console.ReadLine();

            Console.Write("--> Please enter address: [optional]. Press enter if you don't want to: ");
            string address = Console.ReadLine();

            if (!String.IsNullOrEmpty(address))
            {
                contact.Address = address;
            }
        
            return contact;
        }

        public Contact UpdateContact(IList<Contact> contacts)
        {
            Console.Write("Do you want to view all contacts before update? [yes - view all contacts, enter - don't view all contacts]: ");
            string input = Console.ReadLine();

            if(input.ToLower().Trim() == "yes")
            {
                ShowContacts(contacts);
            }

            Console.Write("Enter contact's id which one you want to update:  ");
            input = Console.ReadLine();

            int id;

            if(!int.TryParse(input, out id))
            {
                throw new ArgumentException("Please enter valid id.");
            }

            Contact contactToUpdate;

          
            if(contacts.Where(c => c.Id == id).Any())
            {
                Contact contact = contacts.Where(c => c.Id == id).First();
                contactToUpdate = new Contact
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    LastName = contact.LastName,
                    PhoneNumber = contact.PhoneNumber,
                    Address = contact.Address
                };
            }
            else
            { 
                throw new ArgumentException("Contact with id " + input + " does not exist");
            }
            
           

            bool updating = true;
          
            Console.WriteLine("1 - change name, 2 - change lastname, 3 - change phone number, 4 - change address, 5 - exit");

            input = Console.ReadLine();

            int option;

            if (!int.TryParse(input, out option))
            {
                throw new ArgumentException("Please enter an integer");
            }

            switch (option)
            {
                case 1:
                    Console.Write("--> Please enter name: ");
                    contactToUpdate.Name = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("--> Please enter last name: ");
                    contactToUpdate.LastName = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("--> Please enter phone number: ");
                    contactToUpdate.PhoneNumber = Console.ReadLine();
                    break;
                case 4:
                    Console.Write("--> Please enter address: ");
                    contactToUpdate.Address = Console.ReadLine();
                    break;
                case 5:
                    updating = false;
                    break;
                default:
                    Console.WriteLine("Please enter an integer from 1 to 5.");
                    break;
            }


            return contactToUpdate;
        }

        public int DeleteContact(IList<Contact> contacts)
        {
            Console.Write("Do you want to view all contacts before delete? [yes - view all contacts, enter - don't view all contacts]: ");
            string input = Console.ReadLine();

            if (input.ToLower().Trim() == "yes")
            {
                ShowContacts(contacts);
            }

            Console.Write("Enter contact's id which one you want to delete:  ");
            input = Console.ReadLine();

            int id;

            if (!int.TryParse(input, out id))
            {
                throw new ArgumentException("Please enter valid id.");
            }

            return id;
        }
    }
}
