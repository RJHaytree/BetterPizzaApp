using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // TODO - Expand to include other database tables for receipt upload
        }

        /// <summary>
        /// Generate the employee table - Primarily used for the login form.
        /// </summary>
        private static void GenerateEmployeeTbl()
        {
            // query for tbl_employees construction
            string _query =
                $"CREATE TABLE IF NOT EXISTS {Configuration.EmployeeTbl} (" +
                "   ID INT AUTO_INCREMENT NOT NULL," +
                "   username VARCHAR(30) NOT NULL," +
                "   password VARCHAR(30) NOT NULL," +
                "   employeeKey VARCHAR(10) NOT NULL," +
                "   PRIMARY KEY (ID)," +
                "   UNIQUE(employeeKey)" +
                ")engine=innodb";

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
