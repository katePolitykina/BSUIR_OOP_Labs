using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace fabrica
{
    [DataContract ]
    [KnownType(typeof(DecorativeCosmetics))]
    [KnownType(typeof(SkinCare))]
    public abstract class Product
    {
        [DataMember]
        protected String name;
        [DataMember]
        protected String brand;
        [DataMember]
        protected double price;

        public Product(String name, String brand, double price)
        {
            this.name = name;
            this.brand = brand;
            this.price = price;
        }
        public double Price
        {
            set{ price = value; }
            get { return price; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public void printinfo() {
            Console.WriteLine(getinfo());
        }    
        abstract public string getinfo();
        public abstract Bitmap Img();
    }
    
}
