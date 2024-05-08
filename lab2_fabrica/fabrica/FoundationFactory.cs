using CosmeticsBase;
using System;
namespace cosmetics
{
    public class FoundationFactory : Factory
    {
        public Product Create(string name, string brand, double price)
        {
            return new Foundation(name, brand, price, "full", "natural", "2", "liqued");
        }
        public string Name()
        {
            return "Foundation";
        }
        public Type CreatedClassName() { return typeof(Foundation); }

     
    }
}
