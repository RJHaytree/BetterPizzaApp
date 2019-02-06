using BetterPizzaApp.Library.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BetterPizzaApp.Library.Storage
{
    public static class ReceiptUploader
    {
        /// <summary>
        /// ConnectionBuilder object to allow us to easily reference the connection string.
        /// </summary>
        private static readonly ConnectionBuilder Builder = new ConnectionBuilder();

        /// <summary>
        /// Uploads the receipt information (No order or customer info yet) This must be done first as the receipt ID must exists.
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="basePrice"></param>
        /// <param name="delivery"></param>
        /// <param name="final"></param>
        public static void UploadToReceiptTable(string employee, decimal basePrice, decimal delivery, decimal final)
        {
            try
            {
                using (MySqlConnection _connection = Builder.ConnectionString())
                {
                    string _query = $"INSERT INTO {Configuration.ReceiptTbl} VALUES (NULL, '{employee}', '{basePrice}', '{delivery}', '{final}', NOW() )";

                    MySqlCommand _command = new MySqlCommand(_query, _connection);

                    try
                    {
                        _connection.Open();
                        _command.ExecuteNonQuery();
                        _connection.Close();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the latest receipt ID from the database for use in following sql queries.
        /// </summary>
        /// <returns>Receipt ID for use in other queries.</returns>
        public static int GetReceiptID()
        {
            try
            {
                using (MySqlConnection _connection = Builder.ConnectionString())
                {
                    string _query = $"SELECT * FROM {Configuration.ReceiptTbl} ORDER BY ID DESC LIMIT 1";
                    MySqlCommand _command = new MySqlCommand(_query, _connection);

                    try
                    {
                        _connection.Open();

                        MySqlDataReader _reader = _command.ExecuteReader();

                        while (_reader.Read())
                        {
                            return Convert.ToInt32(_reader["ID"]);
                        }

                        _connection.Close();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }

        /// <summary>
        /// Method to upload all pizza data to the MySQL database.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="toppings"></param>
        /// <param name="price"></param>
        /// <param name="id"></param>
        public static void UploadToPizzaTable(string size, string toppings, decimal price, int id)
        {
            string _query = $"INSERT INTO {Configuration.PizzaTbl} VALUES (NULL, '{size}', '{toppings}', '{price}', '{id}')";
            ExecuteBasicQueries(_query);
        }

        /// <summary>
        /// Method to upload all side data to the MySQL database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <param name="id"></param>
        public static void UploadToSideTable(string name, int quantity, decimal price, int id)
        {
            string _query = $"INSERT INTO {Configuration.SideTbl} VALUES (NULL, '{name}', '{quantity}', '{price}', '{id}')";
            ExecuteBasicQueries(_query);
        }

        /// <summary>
        /// Method to upload all drink data to the MySQL database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <param name="id"></param>
        public static void UploadToDrinkTable(string name, int quantity, decimal price, int id)
        {
            string _query = $"INSERT INTO {Configuration.DrinkTbl} VALUES (NULL, '{name}', '{quantity}', '{price}', '{id}')";
            ExecuteBasicQueries(_query);
        }

        /// <summary>
        /// Method to upload all customer data to the MySQL database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="postcode"></param>
        public static void UploadToCustomerTable(string name, string address, string postcode, int id)
        {
            string _query = $"INSERT INTO {Configuration.CustomerTbl} VALUES (NULL, '{name}', '{address}', '{postcode}', '{id}')";
            ExecuteBasicQueries(_query);
        }

        /// <summary>
        /// Method to send regular database queries to MySQL for execution.
        /// </summary>
        /// <param name="query"></param>
        private static void ExecuteBasicQueries(string query)
        {
            try
            {
                using (MySqlConnection _connection = Builder.ConnectionString())
                {
                    MySqlCommand _command = new MySqlCommand(query, _connection);

                    try
                    {
                        _connection.Open();
                        _command.ExecuteNonQuery();
                        _connection.Close();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
