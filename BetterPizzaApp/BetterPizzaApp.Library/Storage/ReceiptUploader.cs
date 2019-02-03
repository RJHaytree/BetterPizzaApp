using BetterPizzaApp.Library.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterPizzaApp.Library.Storage
{
    public static class ReceiptUploader
    {
        /// <summary>
        /// ConnectionBuilder object to allow us to easily reference the connection string
        /// </summary>
        private static readonly ConnectionBuilder Builder = new ConnectionBuilder();

        /// <summary>
        /// A method dedicated to the uploading of a receipt to the MySQL database.
        /// </summary>
        /// <param name="receipt"></param>
        public static void UploadReceipt(ReceiptModel receipt)
        {
            string _query = $"";

            try
            {
                using (MySqlConnection _connection = Builder.ConnectionString())
                {
                    _connection.Open();
                    MySqlCommand _command = new MySqlCommand(_query, _connection);
                    _command.ExecuteNonQuery();
                    _connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
