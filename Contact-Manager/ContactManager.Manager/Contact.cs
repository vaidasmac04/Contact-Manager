using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactManager.ContactManager.Manager
{
    public class Contact
    {
        [NonSerialized]
        public static int LastId = 0;

        [NonSerialized]
        private int id;
        public int Id { 
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        [NonSerialized]
        private string name;
        public string Name
        { 
            get
            {
                return name;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value.Trim();
            }
        }
        [NonSerialized]
        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be empty");
                }

                lastName = value.Trim();
            }
        }

        [NonSerialized]
        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Phone number cannot be empty");
                }

                if(!Regex.IsMatch(value, @"\d+"))
                {
                    throw new ArgumentException("Phone number can only contain integers");
                }

                phoneNumber = value.Trim();
            }
        }

        [NonSerialized]
        private string address;

        public String Address 
        {

            get
            {
                if (String.IsNullOrEmpty(address))
                {
                    return "-";
                }

                return address;
            }

            set
            {
                address = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0,-4} {1,-25} {2,-25} {3, -15} {4, -40}", Id, Name, LastName, PhoneNumber, Address);
        }
    }
}
