using System;

namespace fabrica
{
    
    public abstract class DecorativeCosmetics : Product
    {
       protected int shade;
       protected String texture;
       protected DecorativeCosmetics(String name, String brand, double price, int shade, String texture) : base( name,  brand, price)
       {
            this.shade = shade;
            this.texture = texture;
        }

    }
}
