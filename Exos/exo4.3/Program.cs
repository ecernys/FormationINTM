using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo4._3
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();
            try
            {
                phoneBook.DisplayPhoneBook();
                //phoneBook.PhoneContact("012345678999999");
                //phoneBook.PhoneContact("0123d56789");
                //phoneBook.PhoneContact("9123d56789");
                //phoneBook.PhoneContact("12313211");
                //phoneBook.PhoneContact("qdsdqqdddd");
                //phoneBook.PhoneContact("");
                //phoneBook.AddPhoneNumber("0123456789", "");
                phoneBook.AddPhoneNumber("012345678999", "Lucas");
                //phoneBook.PhoneContact("0123456789");
                //phoneBook.DisplayPhoneBook();
                ////phoneBook.DeletePhoneNumber("0123456788");
                //phoneBook.DeletePhoneNumber("0123456789");
                //phoneBook.DisplayPhoneBook();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            Console.ReadKey();





        }
    }
}
