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
            ReceiptTbl = GetReceiptTbl();
            PizzaTbl = GetPizzaTbl();
            SideTbl = GetSideTbl();
            DrinkTbl = GetDrinkTbl();
            CustomerTbl = GetCustomerTbl();
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
        /// Name of receipt table - used in sql statements
        /// </summary>
        public static string ReceiptTbl { get; private set; }

        /// <summary>
        /// Name of pizza table - used for sql statements
        /// </summary>
        public static string PizzaTbl { get; private set; }

        /// <summary>
        /// Name of side table - used for sql statements
        /// </summary>
        public static string SideTbl { get; private set; }

        /// <summary>
        /// Name of drink table - used for sql statements
        /// </summary>
        public static string DrinkTbl { get; private set; }

        /// <summary>
        /// Name of customer table - used for sql statements
        /// </summary>
        public static string CustomerTbl { get; private set; }

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

        /// <summary>
        /// Private method which returns receipt table name
        /// </summary>
        /// <returns>Receipt table name as a string</returns>
        private static string GetReceiptTbl()
        {
            return ConfigurationManager.AppSettings["tbl_receipts"];
        }

        /// <summary>
        /// Private method which returns pizza table name
        /// </summary>
        /// <returns>Pizza table name as a string</returns>
        private static string GetPizzaTbl()
        {
            return ConfigurationManager.AppSettings["tbl_pizzas"];
        }

        /// <summary>
        /// Private method which returns side table name
        /// </summary>
        /// <returns>Side table name as a string</returns>
        private static string GetSideTbl()
        {
            return ConfigurationManager.AppSettings["tbl_sides"];
        }

        /// <summary>
        /// Private method which returns drink table name 
        /// </summary>
        /// <returns>Drink table name as a string</returns>
        private static string GetDrinkTbl()
        {
            return ConfigurationManager.AppSettings["tbl_drinks"];
        }

        /// <summary>
        /// Private method which returns customer table name
        /// </summary>
        /// <returns>Customer table name as a string</returns>
        private static string GetCustomerTbl()
        {
            return ConfigurationManager.AppSettings["tbl_customers"];
        }
    }
}
