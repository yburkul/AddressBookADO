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
    }
}