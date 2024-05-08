using CosmeticsBase;
using System;
namespace cosmetics
{
    public class SerumFactory : Factory
    {
        public Product Create(string name, string brand, double price)
        {
            return new Serum(name, brand, price, "Niainaide", true, "1 mounth");
        }

        public string Name()
        {
            return "Serum";
        }

        public Type CreatedClassName() { return typeof(Serum); }
    }
}
