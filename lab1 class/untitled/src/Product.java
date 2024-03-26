public abstract class Product {
    protected final String name;
    protected final String brand;
    protected double price;
    protected final String scent;

    public Product(String name, String brand, double price , String scent) {
        this.name = name;
        this.brand = brand;
        this.price = price;
        this.scent = scent;
    }
    public void apply(){
        System.out.println("Applying " + name + " ...");
    };

    public void setPrice(double price) {
        this.price = price;
    }
    abstract public void printinfo();
}

