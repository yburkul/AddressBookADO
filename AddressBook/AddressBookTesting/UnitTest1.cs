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
        /// TC 1 - Add The Contact in Address Book
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
        /// <summary>
        /// TC 2- Update the Address Book Contact
        /// </summary>
        [Test]
        public void Update_AddressBook_ContactInDB()
        {
            bool expected = true;
            book.ID = 5;
            book.FirstName = "Ritesh";
            book.LastName = "Shelke";
            book.Address = "Akola";
            book.City = "Amravati";
            book.State = "MH";
            book.ZipCode = 340045;
            book.PhoneNumber = 8805320078;
            book.EmailID = "shelke123@gmail.com";
            bool result = address.UpdateContact(book);
            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// TC - Remove Contact From Address Book
        /// </summary>
        [Test]
        public void Given_ID_ToRemove_ContactFromAddressBook()
        {
            bool expected = true;
            book.ID = 6;
            bool result = address.RemoveContact(book);
            Assert.AreEqual(expected, result);
        }
    }
}