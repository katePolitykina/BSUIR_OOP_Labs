using System;

namespace fabrica
{
    public abstract class Factory
    {
        public abstract Product Create(String name, String brand, double price);
    }
}
