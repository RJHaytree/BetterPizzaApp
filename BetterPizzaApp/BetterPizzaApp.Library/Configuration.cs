using System.Configuration;

namespace BetterPizzaApp.Library
{
    public static class Configuration
    {
        /// <summary>
        /// Populate variables with database credentials
        /// </summary>
        public static void PopulateVariables()
        {
            Hostname = GetHostname();
            Username = GetUsername();
            Database = GetDatabase();
            Password = GetPassword();
            EmployeeTbl = GetEmployeeTbl();
        }

        /// <summary>
        /// MySQL database hostname / IP. Default value is 'localhost' defined in
        /// App.config
        /// </summary>
        public static string Hostname { get; private set; }

        /// <summary>
        /// MySQL database username. Default value is 'root' defined in App.config
        /// </summary>
        public static string Username { get; private set; }

        /// <summary>
        /// MySQL database name. Default value is 'BetterPizzaApp_db' defined in
        /// App.config
        /// </summary>
        public static string Database { get; private set; }

        /// <summary>
        /// MySQL username password. Default value is '' or null defined in App.config
        /// </summary>
        public static string Password { get; private set; }

        /// <summary>
        /// Name of employee table - used in sql statements
        /// </summary>
        public static string EmployeeTbl { get; private set; }

        /// <summary>
        /// Private method which returns hostname from app.config
        /// </summary>
        /// <returns>MySQL hostname as a string</returns>
        private static string GetHostname()
        {
            return ConfigurationManager.AppSettings["hostname"];
        }

        /// <summary>
        /// Private method which returns username from app.config
        /// </summary>
        /// <returns>MySQL UID as a string</returns>
        private static string GetUsername()
        {
            return ConfigurationManager.AppSettings["username"];
        }

        /// <summary>
        /// Private method which returns db name form app.config
        /// </summary>
        /// <returns>MySQL database name as a string</returns>
        private static string GetDatabase()
        {
            return ConfigurationManager.AppSettings["database"];
        }

        /// <summary>
        /// Private method which returns uid password from app.config
        /// </summary>
        /// <returns>MySQL uid password as a string</returns>
        private static string GetPassword()
        {
            return ConfigurationManager.AppSettings["password"];
        }

        /// <summary>
        /// Private method which returns employee tbl name
        /// </summary>
        /// <returns>Employee table name as a string</returns>
        private static string GetEmployeeTbl()
        {
            return ConfigurationManager.AppSettings["tbl_employee"];
        }
    }
}
