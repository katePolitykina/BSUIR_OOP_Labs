using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace fabrica
{
    [DataContract]
    public class Mascara:DecorativeCosmetics
    {
        [DataMember]
        private String brushType;
        public Mascara(String name, String brand, double price, String shade, String texture, String brushType): base(name, brand, price, shade, texture)
        {
            this.brushType = brushType;
        }
        public String Brush { 
            get => brushType;
            set => brushType = value;
        }
        public override Bitmap Img()
        {
            return (Bitmap)Bitmap.FromFile(".//img//mascara.png");
        }

        public override string getinfo()
        {
            String info =
            "Name: " + name + "\r\n" +
            "Brand: " + brand + "\r\n" +
            "Price: " + price + "$" + "\r\n" +
            "Shade: " + shade + "\r\n" +
            "Texture: " + texture + "\r\n" +
            "brushType: " + brushType + "\r\n";
            return info;
        }
    }
}
