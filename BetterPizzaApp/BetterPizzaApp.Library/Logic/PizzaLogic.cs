using System.Collections.Generic;
using BetterPizzaApp.Library.Models;

namespace BetterPizzaApp.Library.Logic
{
    /// <summary>
    /// A static class full of methods used for manipulating the pizza object.
    /// </summary>
    public static class PizzaLogic
    {
        /// <summary>
        /// Method used to create a new pizza object.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="toppings"></param>
        /// <returns>A new pizza object which will then be added to the pizzas list.</returns>
        public static PizzaModel CreatePizza(string size, List<string> toppings)
        {
            PizzaModel p = new PizzaModel();
            p.Size = size;
            
            foreach (string t in toppings)
            {
                p.Toppings.Add(t);
            }

            p.TotalToppings = p.Toppings.Count;
            p.Price = p.CalculatePizzaPrice(size, p.TotalToppings);

            // return the populated pizza object to be added to the list.
            return p;
        }

        /// <summary>
        /// Method to update an existing pizza object.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="size"></param>
        /// <param name="toppings"></param>
        /// <returns>An updated pizza object.</returns>
        public static PizzaModel UpdatePizza(PizzaModel p, string size, List<string> toppings)
        {
            p.Toppings.Clear();
            p.Size = size;
            
            foreach (string t in toppings)
            {
                p.Toppings.Add(t);
            }

            p.TotalToppings = p.Toppings.Count;
            p.Price = p.CalculatePizzaPrice(size, p.TotalToppings);

            // return the updated pizza object.
            return p;
        }
    }
}
