using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_part_4_Omer_and_Roaa
{
    public class Buyer : User
    {
        private List<Product> cart;
        public List<List<Product>> CartHistory { get; private set; }

        public Buyer(string username, string password, string country, string city, string street, int house)
            : base(username, password, country, city, street, house)
        {
            cart = new List<Product>();
            CartHistory = new List<List<Product>>();
        }

        public List<Product> GetCart() { return cart; }
        public bool SetCart(List<Product> cart)
        {
            this.cart = cart;
            return true;
        }

        public double TotalCartValue => cart.Sum(p => p.GetPrice());

        public static Buyer operator +(Buyer b, Product p)
        {
            b.cart.Add(p);
            return b;
        }

        public static bool operator <(Buyer b1, Buyer b2)
        {
            return b1.TotalCartValue < b2.TotalCartValue;
        }

        public static bool operator >(Buyer b1, Buyer b2)
        {
            return b1.TotalCartValue > b2.TotalCartValue;
        }
    }
}
