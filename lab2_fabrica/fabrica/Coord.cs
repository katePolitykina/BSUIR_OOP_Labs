using System.Runtime.Serialization;

namespace fabrica
{
    [DataContract]
    public class Coord
    {
        [DataMember]
        public Product self;
        [DataMember]
        public int x, y;
        
        public Coord(Product obj, int X, int Y, int nameToShow)
        {
            self = obj;
            x = X;
            y = Y;
        }
    }
}
