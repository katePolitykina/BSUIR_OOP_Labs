
namespace fabrica
{
    public class Coord
    {
        public Product self;
        public int x, y;
        public const int width = 60;
        public const int height = 140;
        public int nameToShow;
        public Coord(Product obj, int X, int Y, int nameToShow)
        {
            self = obj;
            x = X;
            y = Y;
            this.nameToShow = nameToShow;
        }
    }
}
