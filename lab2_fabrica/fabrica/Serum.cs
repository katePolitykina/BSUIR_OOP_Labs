using System;
using System.Drawing;
using System.Text;

namespace fabrica
{
    internal class Serum : SkinCare
    {
        private Boolean hyppoallergenic;
        private String speedOfAction;
        public Serum(String name, String brand, double price, String activeComponent, Boolean hyppoallergenic, String speedOfAction):base (name, brand, price, activeComponent)
        {
            this.hyppoallergenic = hyppoallergenic;
            this.speedOfAction = speedOfAction;
        }

        public override string getinfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(name + "\n");
            sb.Append("Brand: " + brand + "\n");
            sb.Append("Price: " + price + "$" + "\n");
            if (hyppoallergenic)
            {
                sb.Append("Hyppoallergetic \n");
            }
            return sb.ToString();
        }

        public override Bitmap Img()
        {
            Console.WriteLine(" kkkkkkk");
            return (Bitmap)Bitmap.FromFile(".//img//serum.png");
        }

    }
}
