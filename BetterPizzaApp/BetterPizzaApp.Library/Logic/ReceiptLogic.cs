using BetterPizzaApp.Library.Models;
using BetterPizzaApp.Library.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterPizzaApp.Library.Logic
{
    /// <summary>
    /// Static class dedicated to methods which create and populate a ReceiptModel object.
    /// </summary>
    public static class ReceiptLogic
    {
        /// <summary>
        /// Generate a CustomerInfo using customer information from the form.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="postcode"></param>
        /// <returns>A CustomerInfo object which holds customer name, address and postcode.</returns>
        public static CustomerInfo CreateCustomer(string name, string address, string postcode)
        {
            CustomerInfo c = new CustomerInfo
            {
                Name = name,
                Address = address,
                Postcode = postcode
            };

            return c;
        }

        /// <summary>
        /// Generate a OrderItems object which holds all order components.
        /// </summary>
        /// <param name="pizzas"></param>
        /// <param name="sides"></param>
        /// <param name="drinks"></param>
        /// <returns>A OrderItems object which holds a list of pizzas, sides and drinks from the form.</returns>
        public static OrderItems PopulateOrderItems(List<PizzaModel> pizzas, List<SideModel> sides, List<DrinkModel> drinks)
        {
            OrderItems items = new OrderItems
            {
                OrderPizza = pizzas,
                OrderSide = sides,
                OrderDrink = drinks
            };

            return items;
        }

        /// <summary>
        /// Generate a MonetaryValues object which holds all monetary values for the order.
        /// </summary>
        /// <param name="deals"></param>
        /// <param name="baseCost"></param>
        /// <param name="delivery"></param>
        /// <param name="final"></param>
        /// <returns>A Monetaryvalues object which holds a list of deals, and then values for base, delivery and final costs.</returns>
        public static MonetaryValues PopulateMonetaryValues(List<string> deals, decimal baseCost)
        {
            decimal delivery = CalcDeliveryCost(baseCost);

            MonetaryValues money = new MonetaryValues
            {
                OrderDeals = deals,
                BaseCost = baseCost,
                DeliveryCost = delivery,
                FinalCost = delivery += baseCost
            };

            return money;
        }

        /// <summary>
        /// A method which calculates the delivery cost (Which is 10% of the base price).
        /// </summary>
        /// <param name="price"></param>
        /// <returns>Delivery cost as a decimal.</returns>
        public static decimal CalcDeliveryCost(decimal price)
        {
            return price * 0.10m;
        }

        /// <summary>
        /// Create and populate a ReceiptModel object using already created objects.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="items"></param>
        /// <param name="money"></param>
        /// <returns>A complete ReceiptModel object ready for storage.</returns>
        public static ReceiptModel CreateReceipt(CustomerInfo customer, OrderItems items, MonetaryValues money)
        {
            ReceiptModel r = new ReceiptModel
            {
                CustomerName = customer.Name,
                CustomerAddressLine1 = customer.Address,
                CustomerPostCode = customer.Postcode,

                PizzaList = items.OrderPizza,
                SideList = items.OrderSide,
                DrinkList = items.OrderDrink,

                OrderBaseCost = money.BaseCost,
                OrderDeliveryCost = money.DeliveryCost,
                OrderReceiptCost = money.FinalCost,

                EmployeeKey = EmployeeAuthenticator.EmployeeKey
            };

            return r;
        }
    }

    /// <summary>
    /// CustomerInfo class contains name, address and postcode of the customer.
    /// </summary>
    public class CustomerInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
    }

    /// <summary>
    /// OrderItems class contains a list of pizzas, sides and drinks from the order.
    /// </summary>
    public class OrderItems
    {
        public List<PizzaModel> OrderPizza = new List<PizzaModel>();
        public List<SideModel> OrderSide = new List<SideModel>();
        public List<DrinkModel> OrderDrink = new List<DrinkModel>();
    }

    /// <summary>
    /// MonetaryValues class contains a list of deals, and then all monetary values for the order.
    /// </summary>
    public class MonetaryValues
    {
        public List<string> OrderDeals = new List<string>();
        public decimal BaseCost { get; set; }
        public decimal DeliveryCost { get; set; }
        public decimal FinalCost { get; set; }
    }
}
