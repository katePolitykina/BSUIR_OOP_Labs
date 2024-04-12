namespace fabrica
{
    public class SerumFactory : Factory
    {
        public override Product Create(string name, string brand, double price)
        {
            return new Serum(name, brand, price, "Niainaide", true, "1 mounth");
        }
    }
}
