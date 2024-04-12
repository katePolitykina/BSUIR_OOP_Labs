using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace fabrica
{
    [DataContract]

    public class Foundation : DecorativeCosmetics
    {
        [DataMember]
        private  String coverage;
        [DataMember]
        private  String finish;

        public Foundation(String name, String brand, double price, String coverage, String finish,  String shade, String texture): base(name, brand, price, shade, texture)
        {
            this.coverage = coverage;
            this.finish = finish;
        }
        public String Coverage { 
            get{ return coverage; }
            set { coverage = value; }
        }
        public String Finish
        {
            get { return finish; }
            set { finish = value; }
        }

        public override string getinfo()
        {
            String info = "Name: " + name + "\r\n" +
                "Brand: " + brand + "\r\n" +
                "Price: " + price + "$" + "\r\n" +
                "Shade: " + shade + "\r\n" +
                "Texture: " + texture + "\r\n" +
                "Coverage: " + coverage + "\r\n" +
                "Finish: " + finish + "\r\n";
            return info;
        }

        public override Bitmap Img()
        {
            return (Bitmap)Bitmap.FromFile(".//img//foundation.png");
        }
    


    }
}
