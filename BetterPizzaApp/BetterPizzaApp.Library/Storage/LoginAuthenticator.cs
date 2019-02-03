using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterPizzaApp.Library.Storage
{
    /// <summary>
    /// A set of methods dedicated to the checking of login credentials for the 
    /// login form.
    /// </summary>
    public static class LoginAuthenticator
    {
        /// <summary>
        /// ConnectionBuilder object to allow us to easily reference the connection string
        /// </summary>
        private static readonly ConnectionBuilder Builder = new ConnectionBuilder();

        /// <summary>
        /// A method to check whether login credentials are correct.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>A boolean saying whether the login process was successful.</returns>
        public static bool CheckCredentials(string username, string password)
        {
            bool match = false;
            string _query = $"SELECT * FROM {Configuration.EmployeeTbl} WHERE username = @Username";

            try
            {
                using (MySqlConnection _connection = Builder.ConnectionString())
                {
                    MySqlCommand _command = new MySqlCommand(_query, _connection);
                    _command.Parameters.Add("@Username", MySqlDbType.VarChar);
                    _command.Parameters["@Username"].Value = username;

                    try
                    {
                        _connection.Open();

                        MySqlDataReader _reader = _command.ExecuteReader();

                        while (_reader.Read() && match == false)
                        {
                            if (Convert.ToString(_reader["password"]) == password)
                            {
                                match = true;
                                return match;
                            }
                        }

                        _connection.Close();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return match;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return match;
            }

            return match;
        }
    }
}
