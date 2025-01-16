using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_commerce_part_4_Omer_and_Roaa
{
    public partial class Form1 : Form
    {
        private Manager manager = new Manager();
        const string filePath = "data.json";

        public Form1()
        {
            InitializeComponent();
            manager.LoadData(filePath);
        }

        private void btnAddBuyer_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string country = txtCountry.Text;
            string city = txtCity.Text;
            string street = txtStreet.Text;
            int house = int.Parse(txtHouse.Text);
            manager.AddBuyer(new Buyer(username, password, country, city, street, house));
            MessageBox.Show("Buyer added successfully!");
        }

        private void btnAddSeller_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string country = txtCountry.Text;
            string city = txtCity.Text;
            string street = txtStreet.Text;
            int house = int.Parse(txtHouse.Text);
            manager.AddSeller(new Seller(username, password, country, city, street, house));
            MessageBox.Show("Seller added successfully!");
        }

        private void btnAddProductToSeller_Click(object sender, EventArgs e)
        {
            string sellerUsername = txtSellerUsername.Text;
            Seller seller = manager.GetSellers().FirstOrDefault(s => s.GetUsername() == sellerUsername);
            if (seller == null)
            {
                MessageBox.Show("Seller not found.");
                return;
            }

            int serialNumber = int.Parse(txtSerialNumber.Text);
            string name = txtProductName.Text;
            double price = double.Parse(txtPrice.Text);
            Category category = (Category)Enum.Parse(typeof(Category), cmbCategory.SelectedItem.ToString());
            manager.AddProductToSeller(seller, new Product(serialNumber, name, price, category));
            MessageBox.Show("Product added to seller successfully!");
        }

        private void btnAddProductToBuyerCart_Click(object sender, EventArgs e)
        {
            string buyerUsername = txtBuyerUsername.Text;
            Buyer buyer = manager.GetBuyers().FirstOrDefault(b => b.GetUsername() == buyerUsername);
            if (buyer == null)
            {
                MessageBox.Show("Buyer not found.");
                return;
            }

            int serialNumber = int.Parse(txtSerialNumber.Text);
            string name = txtProductName.Text;
            double price = double.Parse(txtPrice.Text);
            Category category = (Category)Enum.Parse(typeof(Category), cmbCategory.SelectedItem.ToString());
            manager.AddProductToBuyerCart(buyer, new Product(serialNumber, name, price, category));
            MessageBox.Show("Product added to buyer's cart successfully!");
        }

        private void btnBuyerPlaceOrder_Click(object sender, EventArgs e)
        {
            string buyerUsername = txtBuyerUsername.Text;
            Buyer buyer = manager.GetBuyers().FirstOrDefault(b => b.GetUsername() == buyerUsername);
            if (buyer == null)
            {
                MessageBox.Show("Buyer not found.");
                return;
            }

            try
            {
                Order order = new Order(buyer, buyer.GetCart());
                MessageBox.Show("Order placed successfully! Total price: " + order.GetTotalPrice());
                buyer.GetCart().Clear();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            manager.SaveData(filePath);
            MessageBox.Show("Data saved successfully!");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            manager.SaveData(filePath);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
