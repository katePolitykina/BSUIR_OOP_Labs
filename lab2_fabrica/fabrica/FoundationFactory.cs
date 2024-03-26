namespace fabrica
{
    public class FoundationFactory : Factory
    {
        public override Product Create(string name, string brand, double price)
        {
            return new Foundation(name, brand, price, "full", "natural", 2, "liqued");
        }
    }
}
