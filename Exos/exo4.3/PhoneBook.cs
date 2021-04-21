using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo4._3
{
    public class PhoneBook
    {
        private Dictionary<string, string> _contacts;

        public PhoneBook()
        {
            _contacts = new Dictionary<string, string>();
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            Regex rx = new Regex(@"0[1-9]\d{8}");
            return rx.IsMatch(phoneNumber);

        }
        private bool ContainsPhoneContact(string phoneNumber)
        {
            if (IsValidPhoneNumber(phoneNumber))
                return _contacts.ContainsKey(phoneNumber);
            else
                throw new ArgumentException("Phonenumber is invalid");
        }
        public void PhoneContact(string phoneNumber)
        {
            if (ContainsPhoneContact(phoneNumber))
                Console.WriteLine($"{phoneNumber} : {_contacts[phoneNumber]}");
            else
                throw new ArgumentException("Phone number is not found");
        }
        public void AddPhoneNumber(string phoneNumber, string name)
        {
            if (IsValidPhoneNumber(phoneNumber) && !string.IsNullOrWhiteSpace(name))
            {
                if (ContainsPhoneContact(phoneNumber))
                    throw new ArgumentException("Phone number is used already");
                else
                {
                    Console.WriteLine("Numéro de téléphone ajouté");
                    _contacts.Add(phoneNumber, name);
                }
            }
            else
                throw new ArgumentException("Name can't be empty");
        }

        public void DeletePhoneNumber(string phoneNumber)
        {
            if (IsValidPhoneNumber(phoneNumber))
            {
                if (ContainsPhoneContact(phoneNumber))
                {
                    Console.WriteLine("Numéro de téléphone supprimmé");
                    _contacts.Remove(phoneNumber);
                }
                else
                    throw new ArgumentException("Can't delete, Phone number is not found");
            }
            else
                throw new ArgumentException("Invalid phone number");
        }
        public void DisplayPhoneBook()
        {
            Console.WriteLine("Annuaire téléphonique :");
            Console.WriteLine("-----------------------");
            if (_contacts.Count == 0)
            {
                Console.WriteLine("Annuaire est vide");
            }
            else
            {
                foreach (var c in _contacts)
                {
                    PhoneContact(c.Key);
                }
            }
            Console.WriteLine("-----------------------");
        }
    }
}
