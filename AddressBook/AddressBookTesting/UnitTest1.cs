using AddressBook;
using NUnit.Framework;

namespace AddressBookTesting
{
    public class Tests
    {
        AddressDetails address;
        Addressbook book;
        [SetUp]
        public void Setup()
        {
            address = new AddressDetails();
            book = new Addressbook();
        }
        /// <summary>
        /// TC - Add The Contact in Address Book
        /// </summary>
        [Test]
        public void Add_AddressBookContact_InDataBase()
        {
            bool expected = true;
            book.FirstName = "Sachin";
            book.LastName = "Shelke";
            book.Address = "Rajur";
            book.City = "Jalna";
            book.State = "Maharashtra";
            book.ZipCode = 320045;
            book.PhoneNumber = 7705332108;
            book.EmailID = "sachin113@gmail.com";
            bool result = address.AddContact(book);
            Assert.AreEqual(expected, result);
        }
    }
}