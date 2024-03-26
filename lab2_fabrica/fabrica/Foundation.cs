using System;
using System.Drawing;
using System.Text;

namespace fabrica
{
    public class Foundation : DecorativeCosmetics
    {
        private  String coverage;
        private  String finish;

        public Foundation(String name, String brand, double price, String coverage, String finish,  int shade, String texture): base(name, brand, price, shade, texture)
        {
            this.coverage = coverage;
            this.finish = finish;
        }
        public String getCoverage() { return coverage; }
        public String getFinish() { return finish; }

        public override string getinfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(name + "\n");
            sb.Append("Brand: " + brand + "\n");
            sb.Append("Price: " + price + "$" + "\n");
            sb.Append("Shade: " + shade + "\n");
            sb.Append("Texture: " + texture + "\n");
            sb.Append("Coverage: " + coverage+ "\n");
            sb.Append("Finish: " + finish + "\n");
            return sb.ToString();
        }

        public override Bitmap Img()
        {
            return (Bitmap)Bitmap.FromFile(".//img//foundation.png");
        }
    


    }
}
