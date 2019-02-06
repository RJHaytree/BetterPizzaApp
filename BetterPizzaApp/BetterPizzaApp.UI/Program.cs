using BetterPizzaApp.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetterPizzaApp.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Populate database crendentials
            BetterPizzaApp.Library.Configuration.PopulateVariables();

            // Generate tables on load (if not present already)
            BetterPizzaApp.Library.Storage.InitialiseDatabase.CreateTables();

            // Load login form
            Application.Run(new LoginForm());
        }
    }
}
