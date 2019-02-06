using BetterPizzaApp.Library.Models;

namespace BetterPizzaApp.Library.Logic
{
    /// <summary>
    /// A static class full of methods used for manipulating the side object.
    /// </summary>
    public static class SideLogic
    {
        /// <summary>
        /// Method to create side using parameters such as name, quantity and price.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <returns>A side object with full properties.</returns>
        public static SideModel CreateSide(string name, int quantity, decimal price)
        {
            SideModel s = new SideModel();
            s.Name = name;
            s.Quantity = quantity;
            
            if (name == "Spicy Chicken Wings")
            {
                s.Price += (decimal)(quantity / 10 * 6.00);

                if (quantity % 10 == 5)
                {
                    s.Price += 3.50m;
                }
            }
            else
            {
                s.Price += price * quantity;
            }

            return s;
        }
    }
}
