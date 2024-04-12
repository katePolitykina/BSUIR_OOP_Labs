using System;
using System.Runtime.Serialization;

namespace fabrica
{
  
    [DataContract]
    [KnownType(typeof(Mascara))]
    [KnownType(typeof(Foundation))]
    public abstract class DecorativeCosmetics : Product
    {

        [DataMember]
        protected String shade;

        [DataMember] 
        protected String texture;

        public String Shade
        {
            get { return shade; }
            set { shade = value; }
        }
        public String Texture
        {
            get => texture;    
            set { texture = value; }
        }
        protected DecorativeCosmetics(String name, String brand, double price, String shade, String texture) : base( name,  brand, price)
        {
            this.shade = shade;
            this.texture = texture;
        }

    }
}
