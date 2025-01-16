using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_part_4_Omer_and_Roaa
{
    public class Seller : User
    {
        private List<Product> products;

        public Seller(string username, string password, string country, string city, string street, int house)
            : base(username, password, country, city, street, house)
        {
            products = new List<Product>();
        }

        public List<Product> GetProducts() { return products; }
        public bool SetProducts(List<Product> products) { this.products = products; return true; }

        public static Seller operator +(Seller s, Product p)
        {
            s.products.Add(p);
            return s;
        }
    }
}
