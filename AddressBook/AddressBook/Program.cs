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
                Console.WriteLine("4: Update Contact");
                Console.WriteLine("5: Remove Contact");
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
                    case 4:
                        Addressbook addressbook = new Addressbook();
                        Console.WriteLine("Enter a ID for Update Contact");
                        int Id = int.Parse(Console.ReadLine());
                        addressbook.ID = Id;
                        Console.WriteLine("Enter a First Name");
                        string firstname = Console.ReadLine();
                        addressbook.FirstName = firstname;
                        Console.WriteLine("Enter Last Name");
                        string lastname = Console.ReadLine();
                        addressbook.LastName = lastname;
                        Console.WriteLine("Enter Address");
                        string address = Console.ReadLine();
                        addressbook.Address = address;
                        Console.WriteLine("Enter City");
                        string city = Console.ReadLine();
                        addressbook.City = city;
                        Console.WriteLine("Enter State");
                        string State = Console.ReadLine();
                        addressbook.State = State;
                        Console.WriteLine("Enter Zip");
                        double zip = Convert.ToInt64(Console.ReadLine());
                        addressbook.ZipCode = zip;
                        Console.WriteLine("Enter PhoneNumber");
                        double Phone = Convert.ToInt64(Console.ReadLine());
                        addressbook.PhoneNumber = Phone;
                        Console.WriteLine("Enter Email");
                        string Email = Console.ReadLine();
                        addressbook.EmailID = Email;
                        details.UpdateContact(addressbook);
                        Console.WriteLine("Contact is Updated");
                        break;
                    case 5:
                        Addressbook delete = new Addressbook();
                        Console.WriteLine("Enter a ID For Delete The Contact");
                        int id = int.Parse(Console.ReadLine()); 
                        delete.ID = id;
                        details.RemoveContact(delete);
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