using CosmeticsBase;
using System;
using System.Drawing;
using System.Runtime.Serialization;
namespace BrushPlugin
{
    [DataContract]
    public class Brush : Product
    {
        [DataMember]
        private String purpose;
        public Brush(string name, string brand, double price, String purpose) : base(name, brand, price)
        {
            this.purpose = purpose;
        }
        public String Purpose
        {
            set => purpose = value;
            get => purpose;
        }

        public override string getinfo()
        {
            String info = "Name: " + name + "\r\n" +
                          "Brand: " + brand + "\r\n" +
                          "Price: " + price + "$" + "\r\n" +
                          "Purpose: " + purpose + "\r\n";
            return info;
        }

        public override Bitmap Img()
        {
            return (Bitmap)Bitmap.FromFile("..//..//..//BrushPlugin//img//brush.png");
        }
    }
}
