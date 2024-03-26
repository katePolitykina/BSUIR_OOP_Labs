using System;
namespace fabrica
{
    public abstract class SkinCare : Product
    {
        private String activeComponent;
        protected SkinCare(String name, String brand, double price, String activeComponent) : base(name, brand, price)
        {
            this.activeComponent = activeComponent;
        }
    }
}
