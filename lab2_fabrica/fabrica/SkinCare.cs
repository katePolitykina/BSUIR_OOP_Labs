using System;
using System.Runtime.Serialization;
using CosmeticsBase;
namespace cosmetics
{
    [DataContract]
    [KnownType(typeof(Mask))]
    [KnownType(typeof(Serum))]
    public abstract class SkinCare : Product
    {
        [DataMember]
        protected String activeComponent;
        public String ActiveComponent
        {
            get { return activeComponent; }
            set { activeComponent = value; }
        }
        protected SkinCare(String name, String brand, double price, String activeComponent) : base(name, brand, price)
        {
            this.activeComponent = activeComponent;
        }
    }
}
