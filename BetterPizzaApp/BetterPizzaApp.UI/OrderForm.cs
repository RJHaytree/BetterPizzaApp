using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BetterPizzaApp.Library;
using BetterPizzaApp.Library.Models;
using BetterPizzaApp.Library.Storage;
using BetterPizzaApp.Library.Logic;

namespace BetterPizzaApp.UI
{
    public partial class OrderForm : Form
    {
        private readonly string employeeKey;

        List<PizzaModel> pizzas = new List<PizzaModel>();
        List<SideModel> sides = new List<SideModel>();
        List<DrinkModel> drinks = new List<DrinkModel>();
        List<ReceiptModel> receipts = new List<ReceiptModel>();
        List<string> deals = new List<string>();

        string[] allToppings = new string[] { "Anchovies", "Black olives", "Peppers", "Jalapenos", "Mushroom", "Red onion", "Sweetcorn", "Pepperoni", "Pineapple", "Spicy beef", "Chicken", "Sausage", "Ham", "Tuna" };
        string[] allSizes = new string[] { "Small", "Medium", "Large" };

        public OrderForm(string employeeKeyRef)
        {
            InitializeComponent();
            employeeKey = employeeKeyRef;
        }

        /// <summary>
        /// On form load, populate toppings checklist and size combo box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderForm_Load(object sender, EventArgs e)
        {
            txtEmployeeKey.Text = employeeKey;

            foreach (string topping in allToppings)
            {
                clbToppings.Items.Add(topping);
            }

            foreach (string size in allSizes)
            {
                cbSizes.Items.Add(size);
            }
        }

        /// <summary>
        /// Method called when clicking the app or update pizza button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddUpdatePizza_Click(object sender, EventArgs e)
        {
            // create a temp list of current selected toppings to ensure only selected toppings are passed 
            // to either the add or update pizza methods.
            List<string> tempToppings = new List<string>();

            for (int i = 0; i < allToppings.Length; i++)
            {
                if (clbToppings.GetItemChecked(i))
                {
                    tempToppings.Add(allToppings[i]);
                }
            }

            if (btnAddUpdatePizza.Text == "Add Pizza")
            {
                if (!string.IsNullOrWhiteSpace(cbSizes.Text))
                {
                    pizzas.Add(PizzaLogic.CreatePizza(cbSizes.Text, tempToppings));
                }
                else
                {
                    MessageBox.Show("A size must be selected!");
                }
            }

            else if (btnAddUpdatePizza.Text == "Update Pizza")
            {
                int n = lsbPizzaItems.SelectedIndex;

                if (!string.IsNullOrEmpty(cbSizes.Text) && n > -1)
                {
                    pizzas[n] = PizzaLogic.UpdatePizza(pizzas[n], cbSizes.Text, tempToppings);
                }
                else
                {
                    MessageBox.Show("A size must be selected!");
                }
            }

            // Repopulate listbox, uncheck toppings, ensure button says to add a new pizza, and remove size text.
            PopulatePizzaListBox();
            UncheckToppings();
            btnAddUpdatePizza.Text = "Add Pizza";
            cbSizes.Text = "";
        }

        /// <summary>
        /// Method used to delete the current selected pizza from the order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeletePizza_Click(object sender, EventArgs e)
        {
            int n = lsbPizzaItems.SelectedIndex;

            if (n > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you would like to delete this selected pizza?", "Better Pizza App", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    pizzas.RemoveAt(n);
                }
            }

            PopulatePizzaListBox();
            UncheckToppings();
            btnAddUpdatePizza.Text = "Add Pizza";
            cbSizes.Text = "";
        }

        /// <summary>
        /// Method used to repopulate the lsbPizzaItems list box.
        /// Should be used when a new pizza is added to the pizzas list.
        /// </summary>
        private void PopulatePizzaListBox()
        {
            lsbPizzaItems.Items.Clear();

            foreach (PizzaModel p in pizzas)
            {
                lsbPizzaItems.Items.Add($"Size: {p.Size} | # Toppings: {p.TotalToppings} | £ Price: {p.Price:C}");
            }
        }

        /// <summary>
        /// Method used to repopulate the lsbSidesItems list box.
        /// Should be used when a new side is added to the sides list.
        /// </summary>
        private void PopulateSideListBox()
        {
            lsbSidesItems.Items.Clear();

            foreach (SideModel s in sides)
            {
                lsbSidesItems.Items.Add($"Name: {s.Name} | # Quantity: {s.Quantity} | £ Price: {s.Price:C}");
            }
        }

        /// <summary>
        /// Method used to repopulate the lsbDrinksItems list box. 
        /// Should be used when a new drink is added to the drinks list.
        /// </summary>
        private void PopulateDrinkListBox()
        {
            lsbDrinksItems.Items.Clear();

            foreach (DrinkModel d in drinks)
            {
                lsbDrinksItems.Items.Add($"Name: {d.Name} | # Quantity: {d.Quantity} | £ Price: {d.Price:C}");
            }
        }

        /// <summary>
        /// Method used to uncheck all toppings on the pizza tab, must be used after a pizza has been added
        /// and when a pizza is about to be updated.
        /// </summary>
        private void UncheckToppings()
        {
            for (int i = 0; i < clbToppings.Items.Count; i++)
            {
                clbToppings.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        /// <summary>
        /// When clicking a pizza to update, auto-tick all toppings in the object.
        /// Also change 'Add Pizza' button to say 'Update Pizza' to ensure the update
        /// pizza method runs when the button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbPizzaItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = lsbPizzaItems.SelectedIndex;

            btnAddUpdatePizza.Text = "Update Pizza";

            UncheckToppings();

            for (int i = 0; i < allToppings.Length; i++)
            {
                cbSizes.Text = pizzas[n].Size;

                if (pizzas[n].Toppings.Contains(allToppings[i]) == true)
                {
                    clbToppings.SetItemChecked(i, true);
                }
            }

        }

        /// <summary>
        /// When clicking the button to add sides, run through every combo box and run 
        /// the method to create side objects for every side at once.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSides_Click(object sender, EventArgs e)
        {
            sides.Clear();

            if (nudSideGB.Value > 0)
            {
                sides.Add(SideLogic.CreateSide("Garlic Bread", (int)nudSideGB.Value, 1.70m));
            }

            if (nudSideGBC.Value > 0)
            {
                sides.Add(SideLogic.CreateSide("Garlic Bread / Cheese", (int)nudSideGBC.Value, 2.20m));
            }

            if (nudSideSCW.Value > 0)
            {
                sides.Add(SideLogic.CreateSide("Spicy Chicken Wings", (int)nudSideSCW.Value, 3.50m));
            }

            if (nudSideRFF.Value > 0)
            {
                sides.Add(SideLogic.CreateSide("Reg French Fries", (int)nudSideRFF.Value, 1.00m));
            }

            if (nudSideLFF.Value > 0)
            {
                sides.Add(SideLogic.CreateSide("Large French Fries", (int)nudSideLFF.Value, 1.30m));
            }

            if (nudSideC.Value > 0)
            {
                sides.Add(SideLogic.CreateSide("Coleslaw", (int)nudSideC.Value, 0.70m));
            }

            PopulateSideListBox();
            btnAddSides.Text = "Update Side(s)";
        }

        /// <summary>
        /// When clicking the button to add drinks, run through every combo box and run 
        /// the method to create drink objects for every drink at once.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDrinks_Click(object sender, EventArgs e)
        {
            drinks.Clear();

            if (nudDrinksCoke.Value > 0)
            {
                drinks.Add(DrinkLogic.CreateDrink("Coke", (int)nudDrinksCoke.Value));
            }

            if (nudDrinksPepsi.Value > 0)
            {
                drinks.Add(DrinkLogic.CreateDrink("Pepsi", (int)nudDrinksPepsi.Value));
            }

            if (nudDrinksDietCoke.Value > 0)
            {
                drinks.Add(DrinkLogic.CreateDrink("Diet Coke", (int)nudDrinksDietCoke.Value));
            }

            if (nudDrinks7Up.Value > 0)
            {
                drinks.Add(DrinkLogic.CreateDrink("7-Up", (int)nudDrinks7Up.Value));
            }

            if (nudDrinksFanta.Value > 0)
            {
                drinks.Add(DrinkLogic.CreateDrink("Fanta", (int)nudDrinksFanta.Value));
            }

            if (nudDRinksTango.Value > 0)
            {
                drinks.Add(DrinkLogic.CreateDrink("Tango", (int)nudDRinksTango.Value));
            }

            PopulateDrinkListBox();
            btnAddDrinks.Text = "Update Drink(s)";
        }

        /// <summary>
        /// When clicking the button to go to the overview page, create receipt and populate the text boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToOverview_Click(object sender, EventArgs e)
        {
            CreateReceipt();
            tcOrderForm.SelectedIndex++;
        }

        /// <summary>
        /// Validate customer fields to ensure data meets the constraints of the database.
        /// </summary>
        private void CheckCustomerFields()
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) || string.IsNullOrWhiteSpace(txtCustomerAddress.Text) || string.IsNullOrWhiteSpace(txtCustomerPostcode.Text))
            {
                MessageBox.Show("All customer fields must be filled!");
                tcOrderForm.SelectedIndex = 3;
            }

            if (txtOverviewCustomerPostcode.Text.Length > 6)
            {
                MessageBox.Show("Postcode is too long! Max 6 characters with no spaces.");
            }
        }

        /// <summary>
        /// Create a new receipt object using all data collected from the order so far, and then store this in a list
        /// for use later.
        /// </summary>
        private void CreateReceipt()
        {
            CheckCustomerFields();

            CustomerInfo customer = ReceiptLogic.CreateCustomer(txtCustomerName.Text, txtCustomerAddress.Text, txtCustomerPostcode.Text);
            OrderItems items = ReceiptLogic.PopulateOrderItems(pizzas, sides, drinks);
            MonetaryValues money = ReceiptLogic.PopulateMonetaryValues(deals, CalculateBasePrice());
            ReceiptModel receipt = ReceiptLogic.CreateReceipt(customer, items, money);
            receipts.Add(receipt);
        }

        /// <summary>
        /// Calculate the base price of the entire order.
        /// </summary>
        /// <returns>Base price as a decimal.</returns>
        private decimal CalculateBasePrice()
        {
            decimal basePrice = 0;

            foreach (PizzaModel p in pizzas)
            {
                basePrice += p.Price;
            }

            foreach (SideModel s in sides)
            {
                basePrice += s.Price;
            }

            foreach (DrinkModel d in drinks)
            {
                basePrice += d.Price;
            }

            return basePrice;
        }

        /// <summary>
        /// Populate the overview tab on demand with all information needed.
        /// </summary>
        private void PopulateOverviewTab()
        {
            ReceiptModel r = receipts[0];

            txtOverviewCustomerName.Text = r.CustomerName;
            txtOverviewCustomerAddress.Text = r.CustomerAddressLine1;
            txtOverviewCustomerPostcode.Text = r.CustomerPostCode;

            txtOverviewBaseCost.Text = $"{r.OrderBaseCost:C}";
            txtOverviewDeliveryCost.Text = $"{r.OrderDeliveryCost:C}";
            txtOverviewFinalCost.Text = $"{r.OrderReceiptCost:C}";
        }

        /// <summary>
        /// When clicking to access the overview tab, ensure there is only 1 receipt present and validate the information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tcOrderForm_ChangedIndex(object sender, EventArgs e)
        {
            if (tcOrderForm.SelectedIndex == 4)
            {
                receipts.Clear();
                CreateReceipt();
                PopulateOverviewTab();
            }
        }

        /// <summary>
        /// Process to the previous tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevTab_Click(object sender, EventArgs e)
        {
            if (tcOrderForm.SelectedIndex > 0)
            {
                tcOrderForm.SelectedIndex--;
            }
        }

        /// <summary>
        /// Process to the next tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextTab_Click(object sender, EventArgs e)
        {
            if (tcOrderForm.SelectedIndex < tcOrderForm.TabCount)
            {
                tcOrderForm.SelectedIndex++;
            }
        }

        /// <summary>
        /// When clicking to finish order, ask the employee if the data is ready for uploading, and do the corresponding task.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFinishOrder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure this order is complete?", "Better Pizza App", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // If receipt submitted successfully, give message and ask what the employee wants to do next.
                if (UploadFullReceipt())
                {
                    MessageBox.Show("Receipt has been uploaded!");

                    DialogResult newFormResult = MessageBox.Show("Do you want to create a new order? Saying no will log you out.", "Better Pizza App", MessageBoxButtons.YesNoCancel);

                    // Create a new order form to remove all old data and close the current form.
                    if (newFormResult == DialogResult.Yes)
                    {
                        this.Hide();
                        OrderForm newOrder = new OrderForm(employeeKey);
                        newOrder.Closed += (s, args) => this.Close();
                        newOrder.Show();
                    }
                    // Create a new login form to 'log out' the employee from the system.
                    else if (newFormResult == DialogResult.No)
                    {
                        this.Hide();
                        LoginForm newLogin = new LoginForm();
                        newLogin.FormClosed += (s, args) => this.Close();
                        newLogin.Show();
                    }
                }
            }
        }

        /// <summary>
        /// Method dedicated to the upload receipt process. Runs methods from the library depending on what 
        /// is being uploaded.
        /// </summary>
        /// <returns></returns>
        private bool UploadFullReceipt()
        {
            // Get first and only receipt
            ReceiptModel r = receipts[0];

            // Create receipt in the database first to ensure the other data is able to get access to the receipt ID.
            ReceiptUploader.UploadToReceiptTable(employeeKey, r.OrderBaseCost, r.OrderDeliveryCost, r.OrderReceiptCost);

            // Receipt ID
            int id = ReceiptUploader.GetReceiptID();

            // If ID is present, cycle through everything in the order and run the corresponding methods to upload
            // their data to the database.
            if (id > 0)
            {
                foreach (PizzaModel p in r.PizzaList)
                {
                    ReceiptUploader.UploadToPizzaTable(p.Size, ReceiptUtils.ToppingsToString(p.Toppings), p.Price, id);
                }

                foreach (SideModel s in r.SideList)
                {
                    ReceiptUploader.UploadToSideTable(s.Name, s.Quantity, s.Price, id);
                }

                foreach (DrinkModel d in r.DrinkList)
                {
                    ReceiptUploader.UploadToDrinkTable(d.Name, d.Quantity, d.Price, id);
                }

                // Upload customer information
                ReceiptUploader.UploadToCustomerTable(r.CustomerName, r.CustomerAddressLine1, r.CustomerPostCode, id);

                return true;
            }
            else
            {
                MessageBox.Show("Receipt ID not found! Report to a developer immediately.");
            }

            return false;
        }
    }
}
