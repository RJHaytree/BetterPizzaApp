using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterPizzaApp.Library.Models
{
    /// <summary>
    /// Model used for every pizza in the order. Includes: 
    /// size, toppings, number of toppings, and price (decimal)
    /// </summary>
    public class PizzaModel
    {
        /// <summary>
        /// Represents the size of the pizza; small, medium or large.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Represents a list of all toppings for the pizza object.
        /// </summary>
        public List<string> Toppings { get; set; } = new List<string>();

        /// <summary>
        /// Represents the total number of toppings for this pizza object.
        /// Makes calculations far easier due to having a constant reference.
        /// </summary>
        public int TotalToppings { get; set; }

        /// <summary>
        /// Represents the total price for the pizza object. 
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Calculate base price of the pizza using the size and number of toppings.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="toppings"></param>
        /// <returns>Base price of pizza as a decimal.</returns>
        public decimal CalculatePizzaPrice(string size, int toppings)
        {
            decimal price = 0;

            if (size == "Small")
            {
                price += 3.50m + (toppings * 0.8m);
            }
            else if (size == "Medium")
            {
                price += 5.00m + (toppings * 0.8m);
            }
            else if (size == "Large")
            {
                price += 7.00m + (toppings * 0.8m);
            }

            return price;
        }
    }
}
