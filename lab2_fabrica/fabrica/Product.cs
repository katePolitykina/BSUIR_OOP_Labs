using System;
using System.Drawing;

namespace fabrica
{

    public abstract class Product
    {
        protected String name;
        protected String brand;
        protected double price;

        public Product(String name, String brand, double price)
        {
            this.name = name;
            this.brand = brand;
            this.price = price;
        }


        public void setPrice(double price)
        {
            this.price = price;
        }
        public void printinfo() {
            Console.WriteLine(getinfo());
        }
        public String getName()
        {
            return name;
        }
        public String getBrand() {  return brand; }
        public double getPrice() { return price; }
        abstract public string getinfo();
        public abstract Bitmap Img();
    }
    
}
