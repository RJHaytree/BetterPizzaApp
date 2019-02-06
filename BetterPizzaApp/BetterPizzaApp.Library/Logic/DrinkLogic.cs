using BetterPizzaApp.Library.Models;

namespace BetterPizzaApp.Library.Logic
{
    /// <summary>
    /// A static class full of methods used for manipulating the drink object.
    /// </summary>
    public static class DrinkLogic
    {
        public static DrinkModel CreateDrink(string name, int quantity)
        {
            decimal price = 0.7m;

            DrinkModel d = new DrinkModel
            {
                Name = name,
                Quantity = quantity,
                Price = price * quantity
            };

            return d;
        }
    }
}
