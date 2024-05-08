using System;

namespace CosmeticsBase
{
    public interface Factory
    {
        Product Create(String name, String brand, double price);
        String Name();
        Type CreatedClassName();
    }
}
