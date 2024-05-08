using CosmeticsBase;
using System;

namespace BrushPlugin
{
    internal class BrushFactory : Factory
    {
        public   Product Create(string name, string brand, double price)
        {
            return new Brush(name, brand, price, "");
        }

        public  string Name()
        {
            return "Brush";
        }
        public Type CreatedClassName() { return typeof(Brush); }
    }
}

