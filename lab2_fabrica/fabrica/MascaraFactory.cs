using CosmeticsBase;
using System;
namespace cosmetics
{

    public class MascaraFactory : Factory
    {
        public Type CreatedClassName () { return typeof(Mascara); }
        public Product Create(string name, string brand, double price)
        {
            return new Mascara(name, brand, price, "3", "liquid", "Hourglass (volume)");
        }
        public string Name() { return "Mascara"; }
    }
}
