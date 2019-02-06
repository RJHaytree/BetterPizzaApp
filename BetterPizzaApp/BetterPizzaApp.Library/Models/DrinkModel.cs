namespace BetterPizzaApp.Library.Models
{
    /// <summary>
    /// Model used for every drink in the order. Must receive a 
    /// name, quantity and a price.
    /// </summary>
    public class DrinkModel
    {
        /// <summary>
        /// Represents the name of this drink object (Typically the brand.)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the quantity of this drink to be added to the order.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Represents a reference the price of this single drink object.
        /// </summary>
        public decimal Price { get; set; }
    }
}
