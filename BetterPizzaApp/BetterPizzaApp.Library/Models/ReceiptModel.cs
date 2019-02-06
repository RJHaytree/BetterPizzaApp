using System.Collections.Generic;

namespace BetterPizzaApp.Library.Models
{
    /// <summary>
    /// a receipt object must be created when a order has been completed.
    /// The model is a template to ensure the receipt receives all information
    /// needed for the data to be saved successfully.
    /// </summary>
    public class ReceiptModel
    {
        // Customer information

        /// <summary>
        /// Represents the name of the customer associated with this order.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Represents the first line of the customer's address for this order.
        /// </summary>
        public string CustomerAddressLine1 { get; set; }

        /// <summary>
        /// Represents the customer's postcode associated with this order (for delivery.)
        /// </summary>
        public string CustomerPostCode { get; set; }

        // Order information, initialise lists

        /// <summary>
        /// Represents the final list of pizzas in this order.
        /// </summary>
        public List<PizzaModel> PizzaList { get; set; } = new List<PizzaModel>();

        /// <summary>
        /// Represents the final list of sides in this order.
        /// </summary>
        public List<SideModel> SideList { get; set; } = new List<SideModel>();

        /// <summary>
        /// Represents the final list of drinks in this order.
        /// </summary>
        public List<DrinkModel> DrinkList { get; set; } = new List<DrinkModel>();

        // Order cost / Monetary values

        /// <summary>
        /// Represents the price of the order without additional delivery costs.
        /// </summary>
        public decimal OrderBaseCost { get; set; }

        /// <summary>
        /// Represents any additional costs applied for delivery.
        /// </summary>
        public decimal OrderDeliveryCost { get; set; }

        /// <summary>
        /// Represents the final price of this order. Base pice + delivery cost.
        /// </summary>
        public decimal OrderReceiptCost { get; set; }

        /// <summary>
        /// Represents the employee key of the employee creating this order.
        /// </summary>
        public string EmployeeKey { get; set; }
    }
}
