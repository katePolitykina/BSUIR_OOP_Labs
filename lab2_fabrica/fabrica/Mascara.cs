using System;
using System.Drawing;
using System.Text;

namespace fabrica
{
    public class Mascara:DecorativeCosmetics
    {
        private String brushType;
        public Mascara(String name, String brand, double price, int shade, String texture, String brushType): base(name, brand, price, shade, texture)
        {
            this.brushType = brushType;
        }
        public String getBrush() { return brushType; }
        public void setBrush(String brushType) { this.brushType = brushType; }

        public override Bitmap Img()
        {
            return (Bitmap)Bitmap.FromFile(".//img//mascara.png");
        }

        public override string getinfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(name + "\n");
            sb.Append("Brand: " + brand + "\n");
            sb.Append("Price: " + price + "$" + "\n");
            sb.Append("Shade: " + shade + "\n");
            sb.Append("Texture: " + texture + "\n");
            sb.Append("brushType: " + brushType + "\n");
            return sb.ToString();
        }
    }
}
