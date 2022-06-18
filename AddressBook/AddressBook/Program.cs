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