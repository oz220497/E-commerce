using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace E_commerce_part_4_Omer_and_Roaa
{
    public class Manager
    {
        private List<Buyer> buyers;
        private List<Seller> sellers;

        public Manager()
        {
            buyers = new List<Buyer>();
            sellers = new List<Seller>();
        }

        public List<Buyer> GetBuyers() { return buyers; }
        public List<Seller> GetSellers() { return sellers; }

        public void AddBuyer(Buyer buyer)
        {
            buyers.Add(buyer);
        }

        public void AddSeller(Seller seller)
        {
            sellers.Add(seller);
        }

        public void AddProductToSeller(Seller seller, Product product)
        {
            seller += product;
        }

        public void AddProductToBuyerCart(Buyer buyer, Product product)
        {
            buyer += product;
        }

        public void SortSellersByProductCount()
        {
            sellers.Sort((s1, s2) => s2.GetProducts().Count.CompareTo(s1.GetProducts().Count));
        }

        public void CreateNewCartFromHistory(Buyer buyer, int cartIndex)
        {
            if (cartIndex < 0 || cartIndex >= buyer.CartHistory.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid cart index.");
            }
            buyer.SetCart(new List<Product>(buyer.CartHistory[cartIndex]));
        }

        public void SaveData(string filePath)
        {
            var data = new { Buyers = buyers, Sellers = sellers };
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void LoadData(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<dynamic>(json);
                buyers = JsonSerializer.Deserialize<List<Buyer>>(data.Buyers.ToString());
                sellers = JsonSerializer.Deserialize<List<Seller>>(data.Sellers.ToString());
            }
        }
    }
}
