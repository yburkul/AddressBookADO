using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class AddressDetails
    {
        static string connectionString = @"Data Source=DESKTOP-DNLCRQ5\SQLEXPRESS;Initial Catalog=AddressBookService;Integrated Security=True;";
        static SqlConnection sqlConnection = new SqlConnection(connectionString);

        public void EstablishConnection()
        {
            if (sqlConnection != null && sqlConnection.State.Equals(ConnectionState.Closed))
            {
                try
                {
                    sqlConnection.Open();
                    Console.WriteLine("Connection is Open");
                }
                catch (Exception)
                {
                    throw new AddressException(AddressException.ExceptionType.Connection_Failed, "connection failed");

                }
            }
        }
        public void CloseConnection()
        {
            if (sqlConnection != null && sqlConnection.State.Equals(ConnectionState.Open))
            {
                try
                {
                    sqlConnection.Close();
                    Console.WriteLine("Connection is closed");
                }
                catch (Exception)
                {
                    throw new AddressException(AddressException.ExceptionType.Connection_Failed, "connection failed");
                }
            }
        }
        public bool AddContact(Addressbook address)
        {
            try
            {
                List<Addressbook> list = new List<Addressbook>();
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("AddContactInAddressBook", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FirstName", address.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", address.LastName);
                    sqlCommand.Parameters.AddWithValue("@Address", address.Address);
                    sqlCommand.Parameters.AddWithValue("@City", address.City);
                    sqlCommand.Parameters.AddWithValue("@State", address.State);
                    sqlCommand.Parameters.AddWithValue("@ZipCode", address.ZipCode);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", address.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@EmailID", address.EmailID);
                    list.Add(address);
                    Console.WriteLine(address.FirstName + "," + address.LastName + "," + address.Address + "," + address.City + "," + address.State + ","
                           + address.ZipCode + "," + address.PhoneNumber + "," + address.EmailID);
                    sqlConnection.Open();

                    var result = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                throw new AddressException(AddressException.ExceptionType.Contact_Not_Add, "Contact are not added");
            }
        }
    }
}