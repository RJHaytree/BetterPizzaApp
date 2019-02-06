using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterPizzaApp.Library.Storage
{
    public static class ReceiptUtils
    {
        /// <summary>
        /// Convert to pizzas toppings list to a string ready for uploading to the database.
        /// </summary>
        /// <param name="toppings"></param>
        /// <returns></returns>
        public static string ToppingsToString(List<string> toppings)
        {
            return string.Join(",", toppings.ToArray());
        }
    }
}
