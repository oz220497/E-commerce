using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_part_4_Omer_and_Roaa
{
    public class SpecialProduct : Product
    {
        private double specialPackingPrice;

        public SpecialProduct(int serialNumber, string name, double price, Category category, double specialPackingPrice)
            : base(serialNumber, name, price, category)
        {
            this.specialPackingPrice = specialPackingPrice;
        }

        public double GetSpecialPackingPrice() { return specialPackingPrice; }
        public bool SetSpecialPackingPrice(double specialPackingPrice)
        {
            this.specialPackingPrice = specialPackingPrice;
            return true;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nSpecial Packing Price: {specialPackingPrice}";
        }
    }
}
