namespace fabrica
{
    public class MascaraFactory : Factory
    {
        public override Product Create(string name, string brand, double price)
        {
            return new Mascara(name, brand, price, 3, "liquid", "Hourglass (volume)");
        }
    }
}
