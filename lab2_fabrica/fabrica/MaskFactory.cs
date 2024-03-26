namespace fabrica
{
    public class MaskFactory : Factory
    {
        public override Product Create(string name, string brand, double price)
        {
            return new Mask(name, brand, price, "Hyalyronic Acid", 20, "Sheet mask");
        }
    }
}
