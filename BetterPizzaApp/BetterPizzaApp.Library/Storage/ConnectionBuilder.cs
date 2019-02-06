using MySql.Data.MySqlClient;

namespace BetterPizzaApp.Library.Storage
{
    public class ConnectionBuilder
    {
        /// <summary>
        /// Public method to allow easy use of a MySQL connection string for all
        /// MySQL operations.
        /// </summary>
        /// <returns></returns>
        public MySqlConnection ConnectionString()
        {
            return new MySqlConnection($"HOST={Configuration.Hostname};DATABASE={Configuration.Database};UID={Configuration.Username};PASSWORD={Configuration.Password}");
        }
    }
}
