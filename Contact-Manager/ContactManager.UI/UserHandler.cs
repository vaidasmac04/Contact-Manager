using ContactManager.ContactManager.Manager;
using ContactManager.ContactManger.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ContactManager.ContactManager.UI
{
    public class UserHandler
    {
        private enum Commands {Add, Update, Delete, View, Exit };
        private IContactsList contactsList;
        private IContactsSaver contactsSaver;
        private ContactsListUI contactsListUI;

        public UserHandler(IContactsList contactsList, IContactsSaver contactsSaver)
        {
            this.contactsList = contactsList;
            this.contactsSaver = contactsSaver;
            contactsListUI = new ContactsListUI();
        }

        public void ShowConsoleWithOptions()
        {
            bool running = true;

            Console.WriteLine("Note: if you don't use 'exit' command all changes will be lost.");

            do
            {
                Console.WriteLine("1 - add, 2 - update, 3 - delete, 4 - view,  5 - exit");

                try
                {
                    Commands command = FindCommnand(ReadInput());

                    switch (command)
                    {
                        case Commands.Add:
                            contactsList.AddContact(contactsListUI.AddContact());
                            Logger.Log("Contact added");
                            break;
                        case Commands.Update:
                            contactsList.UpdateContact(contactsListUI.UpdateContact(contactsList.GetContacts()));
                            Logger.Log("Contact updated");
                            break;
                        case Commands.Delete:
                            contactsList.DeleteContact(contactsListUI.DeleteContact(contactsList.GetContacts()));
                            Logger.Log("Contact deleted");
                            break;
                        case Commands.View:
                            contactsListUI.ShowContacts(contactsList.GetContacts());
                            break;
                        case Commands.Exit:
                            Console.WriteLine("saving");
                            Logger.Log("Contacts saved");
                            contactsSaver.SaveContacts(contactsList.GetContacts());
                            Console.WriteLine("goodbye!");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("The command is unknown");
                            break;
                    }
                }
                catch(ArgumentException argumentException)
                {
                    ExceptionHandler.PrintMessageToConsole(argumentException);
                }

                Console.WriteLine();
                
            } while (running);
        }

        private int ReadInput()
        {
            string input = Console.ReadLine();
            input = input.Trim();
            int convertedInput;

            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be empty.");
            }

            if (!int.TryParse(input, out convertedInput))
            {
                throw new ArgumentException("Input can only be an integer.");
            }

            return convertedInput;
        }

        private Commands FindCommnand(int input)
        {
            Commands command;
            

            if (input == 1)
            {
                command = Commands.Add;
            }
            else if(input == 2)
            {
                command = Commands.Update;
            }
            else if (input == 3)
            {
                command = Commands.Delete;
            }
            else if (input == 4)
            {
                command = Commands.View;
            }
            else if (input == 5)
            {
                command = Commands.Exit;
            }
            else
            {
                throw new ArgumentException("Input can only be an integer from 1 to 5.");
            }

            return command;
        }
    }
}
