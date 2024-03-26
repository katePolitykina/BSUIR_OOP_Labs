using System;
using System.Drawing;
using System.Text;

namespace fabrica
{
    public class Mask: SkinCare
    {
        private int time;
        private String maskType;
        public Mask(String name, String brand, double price, String activeComponent, int time, String maskType) : base(name, brand, price, activeComponent)
        {
            this.maskType = maskType;
            this.time = time;
        }

        public override string getinfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(name + "\n");
            sb.Append("Brand: " + brand + "\n");
            sb.Append("Price: " + price + "$" + "\n");
            sb.Append("Type: " + maskType + "\n");
            return sb.ToString();
        }

        public override Bitmap Img()
        {
            return (Bitmap)Bitmap.FromFile(".//img//mask.png");
        }
    }
}
