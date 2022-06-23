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
        public bool UpdateContact(Addressbook address)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("EditContact", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", address.ID);
                    command.Parameters.AddWithValue("@FirstName", address.FirstName);
                    command.Parameters.AddWithValue("@LastName", address.LastName);
                    command.Parameters.AddWithValue("@Address", address.Address);
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@State", address.State);
                    command.Parameters.AddWithValue("@ZipCode", address.ZipCode);
                    command.Parameters.AddWithValue("@PhoneNumber", address.PhoneNumber);
                    command.Parameters.AddWithValue("@EmailID", address.EmailID);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                throw new AddressException(AddressException.ExceptionType.Contact_Not_Updated, "Contact not updated");
            }
        }
        public bool RemoveContact(Addressbook address)
        {
            try
            {
                using (sqlConnection)
                {
                    SqlCommand command = new SqlCommand("RemoveContactFromAddressBook", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", address.ID);
                    sqlConnection.Open();
                    var result = command.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (result != 0)
                    {
                        Console.WriteLine("Contact is Deleted");
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        public static List<Addressbook> GetAddressBookDetails()
        {
            List<Addressbook> list = new List<Addressbook>();
            Addressbook address = new Addressbook();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                SqlCommand cmd = new SqlCommand("GetAllAddressBookContact", sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        address.ID = reader.GetInt32(0);
                        address.FirstName = reader.GetString(1);
                        address.LastName = reader.GetString(2);
                        address.Address = reader.GetString(3);
                        address.City = reader.GetString(4);
                        address.State = reader.GetString(5);
                        address.ZipCode = reader.GetInt64(6);
                        address.PhoneNumber = reader.GetInt64(7);
                        address.EmailID = reader.GetString(8);
                        list.Add(address);
                        Console.WriteLine(address.ID + "," + address.FirstName + "," + address.LastName + "," + address.Address + "," + address.City + "," + address.State + ","
                           + address.ZipCode + "," + address.PhoneNumber + "," + address.EmailID);
                    }
                }
                else
                {
                    Console.WriteLine("No Data Found");
                }
                sqlConnection.Close();

            }
            return list;
        }
    }
}