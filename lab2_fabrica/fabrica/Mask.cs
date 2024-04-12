using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;

namespace fabrica
{
    [DataContract]
    public class Mask: SkinCare
    {
        [DataMember]
        private int time;
        [DataMember]
        private String maskType;
        public int Time
        {
            get { return time; }
            set {time = value; }
        }
        public String MaskType
        {
            get { return maskType; }
            set { maskType = value; }
        }

        public Mask(String name, String brand, double price, String activeComponent, int time, String maskType) : base(name, brand, price, activeComponent)
        {
            this.maskType = maskType;
            this.time = time;
        }

        public override string getinfo()
        {
            String info =
            "Name: " + name + "\r\n" +
            "Brand: " + brand + "\r\n" +
            "Price: " + price + "$" + "\r\n" +
            "Type: " + maskType + "\r\n" +
            "Active Component: " + activeComponent + "\r\n" +
            "Time to apply: " + time + " мин \r\n";
            return info;
        }

        public override Bitmap Img()
        {
            return (Bitmap)Bitmap.FromFile(".//img//mask.png");
        }
    }
}
