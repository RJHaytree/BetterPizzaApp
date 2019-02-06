namespace BetterPizzaApp.Library.Models
{
    /// <summary>
    /// Model used for every side in the order. Must receive a 
    /// name, quantity and a price.
    /// </summary>
    public class SideModel
    {
        /// <summary>
        /// Represents the name of this drink object (Typically the type.)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the quantity of this side to be added to the order.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Represents a reference the price of this single side object.
        /// </summary>
        public decimal Price { get; set; }
    }
}
