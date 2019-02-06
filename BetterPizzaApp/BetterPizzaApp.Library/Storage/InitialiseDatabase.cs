using MySql.Data.MySqlClient;
using System;

namespace BetterPizzaApp.Library.Storage
{
    public static class InitialiseDatabase
    {
        /// <summary>
        /// ConnectionBuilder object to allow us to easily reference the connection string
        /// </summary>
        private static readonly ConnectionBuilder Builder = new ConnectionBuilder();

        /// <summary>
        /// Generate database tables which need to be ready on application load.
        /// </summary>
        public static void CreateTables()
        {
            try
            {
                GenerateEmployeeTbl();
                GenerateReceiptTbl();
                GeneratePizzaTbl();
                GenerateSideTbl();
                GenerateDrinkTbl();
                GenerateCustomerTbl();

                Console.WriteLine("DATABASE INITIALISED");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Generate the employee table - Primarily used for the login form.
        /// </summary>
        private static void GenerateEmployeeTbl()
        {
            // query for tbl_employees construction
            string _query = $"CREATE TABLE IF NOT EXISTS {Configuration.EmployeeTbl} ( ID INT AUTO_INCREMENT NOT NULL, username VARCHAR(30) NOT NULL, password VARCHAR(30) NOT NULL, employeeKey VARCHAR(10) NOT NULL, PRIMARY KEY (ID), UNIQUE(employeeKey) )engine=innodb";
            ExecuteDatabaseQuery(_query);
        }

        /// <summary>
        /// Generate the receipt table - Primarily used for upload process.
        /// </summary>
        private static void GenerateReceiptTbl()
        {
            string _query = $"CREATE TABLE IF NOT EXISTS {Configuration.ReceiptTbl} ( ID INT AUTO_INCREMENT NOT NULL, employeeKey VARCHAR(10) NOT NULL, basePrice DECIMAL(19,2) NOT NULL, deliveryPrice DECIMAL(19,2) NOT NULL, finalPrice DECIMAL(19,2) NOT NULL, timestamp DATETIME NOT NULL,PRIMARY KEY(ID), FOREIGN KEY(employeeKey) REFERENCES {Configuration.EmployeeTbl}(employeeKey) )engine=innodb";
            ExecuteDatabaseQuery(_query);
        }

        /// <summary>
        /// Generate the pizza table - primarily used for upload process.
        /// </summary>
        private static void GeneratePizzaTbl()
        {
            string _query = $"CREATE TABLE IF NOT EXISTS {Configuration.PizzaTbl} ( ID INT AUTO_INCREMENT NOT NULL, size VARCHAR(6) NOT NULL, toppings VARCHAR(150) NOT NULL, price DECIMAL(19,2) NOT NULL, receiptID INT NOT NULL, PRIMARY KEY(ID), FOREIGN KEY(receiptID) REFERENCES {Configuration.ReceiptTbl}(ID) )engine=innodb";
            ExecuteDatabaseQuery(_query);
        }

        /// <summary>
        /// Generate the side table - primarily used for the upload process.
        /// </summary>
        private static void GenerateSideTbl()
        {
            string _query = $"CREATE TABLE IF NOT EXISTS {Configuration.SideTbl} ( ID INT AUTO_INCREMENT NOT NULL, name VARCHAR(20) NOT NULL, quantity INT NOT NULL, price DECIMAL(19,2) NOT NULL, receiptID INT NOT NULL, PRIMARY KEY(ID), FOREIGN KEY(receiptID) REFERENCES {Configuration.SideTbl}(ID) )engine=innodb";
            ExecuteDatabaseQuery(_query);
        }

        /// <summary>
        /// Generate the drink table - primarily used for the upload process.
        /// </summary>
        private static void GenerateDrinkTbl()
        {
            string _query = $"CREATE TABLE IF NOT EXISTS {Configuration.DrinkTbl} ( ID INT AUTO_INCREMENT NOT NULL, name VARCHAR(20) NOT NULL, quantity INT NOT NULL, price DECIMAL(19,2) NOT NULL, receiptID INT NOT NULL, PRIMARY KEY(ID), FOREIGN KEY(receiptID) REFERENCES {Configuration.ReceiptTbl}(ID) )engine=innodb";
            ExecuteDatabaseQuery(_query);
        }

        /// <summary>
        /// Generate the customer table - primarily used for the upload process.
        /// </summary>
        private static void GenerateCustomerTbl()
        {
            string _query = $"CREATE TABLE IF NOT EXISTS {Configuration.CustomerTbl} ( ID INT AUTO_INCREMENT NOT NULL, name VARCHAR(50) NOT NULL, address VARCHAR(50) NOT NULL, postcode VARCHAR(6), receiptID INT NOT NULL, PRIMARY KEY(ID), FOREIGN KEY(ID) REFERENCES {Configuration.ReceiptTbl}(ID) )engine=innodb";
            ExecuteDatabaseQuery(_query);
        }

        /// <summary>
        /// Method to execute database queries for this class.
        /// </summary>
        /// <param name="query"></param>
        private static void ExecuteDatabaseQuery(string query)
        {
            try
            {
                using (MySqlConnection _connection = Builder.ConnectionString())
                {
                    _connection.Open();
                    MySqlCommand _command = new MySqlCommand(query, _connection);
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
