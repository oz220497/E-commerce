using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_part_4_Omer_and_Roaa
{
    public class Product
    {
        protected int serialNumber;
        protected string name;
        protected double price;
        protected Category category;

        public Product(int serialNumber, string name, double price, Category category)
        {
            this.serialNumber = serialNumber;
            this.name = name;
            this.price = price;
            this.category = category;
        }

        public int GetSerialNumber() { return serialNumber; }
        public bool SetCategory(Category category)
        {
            this.category = category;
            return true;
        }
        public Category GetCategory() { return category; }
        public string GetName() { return name; }
        public bool SetName(string name)
        {
            this.name = name;
            return true;
        }
        public double GetPrice() { return price; }
        public bool SetPrice(double price)
        {
            this.price = price;
            return true;
        }
        public override string ToString()
        {
            return $"Product serialNumber: {serialNumber}\nName: {name}\nCategory: {category}\nPrice: {price}";
        }
    }

    public enum Category
    {
        Children,
        Electronics,
        Office,
        Clothing
    }
}
