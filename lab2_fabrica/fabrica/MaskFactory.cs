using CosmeticsBase;
using System;
namespace cosmetics
{
    public class MaskFactory : Factory
    {
        public Product Create(string name, string brand, double price)
        {
            return new Mask(name, brand, price, "Hyalyronic Acid", 20, "Sheet mask");
        }
        public string Name()
        {
            return "Mask";
        }
        public Type CreatedClassName() { return typeof(Mask); }
    }
}
