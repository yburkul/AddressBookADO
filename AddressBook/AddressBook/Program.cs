using System;
namespace AddressBook
{
    public class Program
    {
        public static void Main(string[]args)
        {
            Console.WriteLine("Welcome in Address Book System Ado.Net");
            AddressDetails details = new AddressDetails();
            int input = 0;
            do
            {
                Console.WriteLine("1: Establish Connection");
                Console.WriteLine("2: Close Connection");
                Console.WriteLine("3: Add Contact in Address Book");
                Console.WriteLine("0: Exit");
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        details.EstablishConnection();
                        break;
                    case 2:
                        details.CloseConnection();
                        break;
                    case 3:
                        Addressbook addressBook = new Addressbook();
                        Console.WriteLine("Enter First Name");
                        string Firstname = Console.ReadLine();
                        addressBook.FirstName = Firstname;
                        Console.WriteLine("Enter Last Name");
                        string LastName = Console.ReadLine();
                        addressBook.LastName = LastName;
                        Console.WriteLine("Enter Address");
                        string Address = Console.ReadLine();
                        addressBook.Address = Address;
                        Console.WriteLine("Enter City");
                        string City = Console.ReadLine();
                        addressBook.City = City;
                        Console.WriteLine("Enter state");
                        string state = Console.ReadLine();
                        addressBook.State = state;
                        Console.WriteLine("Enter Zip");
                        double Zip = Convert.ToInt64(Console.ReadLine());
                        addressBook.ZipCode = Zip;
                        Console.WriteLine("Enter PhoneNumber");
                        double PhoneNumber = Convert.ToInt64(Console.ReadLine());
                        addressBook.PhoneNumber = PhoneNumber;
                        Console.WriteLine("Enter Email");
                        string email = Console.ReadLine();
                        addressBook.EmailID = email;
                        details.AddContact(addressBook);
                        break;
                    case 0:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid Input:---Please Enter Correct Input");
                        break;
                }
            }
            while (input != 0);
        }
    }
}