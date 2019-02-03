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

namespace BetterPizzaApp.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // check if text fields are empty where they should not be.
            if (!string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                // if method returns true, login successful and create new order form.
                if (LoginAuthenticator.CheckCredentials(txtUsername.Text, txtPassword.Text))
                {
                    MessageBox.Show("Login successful!");
                    OrderForm orderForm = new OrderForm();
                    orderForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid crendentials. Try again!");
                }
            }
            else
            {
                MessageBox.Show("Invalid credentials. Try again!");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Debug statements
        }
    }
}
