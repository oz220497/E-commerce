using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_part_4_Omer_and_Roaa
{
    public class Order
    {
        private User user;
        private List<Product> products;
        private double totalPrice;

        public Order(User user, List<Product> products)
        {
            if (products.Count <= 1)
                throw new ArgumentException("Cannot place an order with only one item in the cart.");

            this.user = user;
            this.products = products;
            this.totalPrice = products.Sum(p => p.GetPrice());
        }

        public User GetUser() { return user; }
        public bool SetUser(User user) { this.user = user; return true; }
        public double GetTotalPrice() { return totalPrice; }
        public bool SetTotalPrice(double totalPrice)
        {
            this.totalPrice = totalPrice;
            return true;
        }
        public List<Product> GetProducts() { return products; }
        public bool SetProducts(List<Product> products) { this.products = products; return true; }
    }
}
