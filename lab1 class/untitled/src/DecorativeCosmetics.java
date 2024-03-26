public abstract class DecorativeCosmetics extends Product{
    protected final int shade;
    protected final String texture;


    protected DecorativeCosmetics(String name, String brand,  double price, int shade, String scent, String texture) {
        super(name, brand, price, scent);
        this.shade = shade;
        this.texture = texture;
    }
    public void remove(){
        System.out.println("Removing " + name + " ...");
    };

}
