using System;
using System.Drawing;
using System.Runtime.Serialization;


namespace cosmetics
{
    [DataContract]   

    
    internal class Serum : SkinCare
    {
        [DataMember]
        private Boolean hyppoallergenic;
        [DataMember]
        private String speedOfAction;
        public Serum(String name, String brand, double price, String activeComponent, Boolean hyppoallergenic, String speedOfAction):base (name, brand, price, activeComponent)
        {
            this.hyppoallergenic = hyppoallergenic;
            this.speedOfAction = speedOfAction;
        }
        public Boolean Hyppoallergenic
        {
            set => hyppoallergenic = value;
            get => hyppoallergenic;
        }
        public String SpeedOfAction
        {
            get => speedOfAction;
            set => speedOfAction = value;
        }

        public override String getinfo()
        {
            String info =
            "Name: " + name + "\r\n" +
            "Brand: " + brand + "\r\n" +
            "Price: " + price + "$" + "\r\n" +
            "Active component: " + activeComponent+ "\r\n";
            if (hyppoallergenic)
            {
                info += "Hyppoallergetic  \r\n";
            }

            info += "Speed of action: " + speedOfAction + "\r\n";
            return info;
        }

        public override Bitmap Img()
        {
            return (Bitmap)Bitmap.FromFile(".//img//serum.png");
        }

    }
}
