public class Mascara extends DecorativeCosmetics{
    private String brushType;
    public Mascara(String name, String brand, double price, int shade, String scent, String texture, String brushType) {
        super(name, brand, price, shade, scent, texture);
        this.brushType = brushType;
    }
    public String getBrush(){return brushType;}
    public void setBrush(String brushType){this.brushType = brushType;}

    @Override
    public void printinfo() {
        System.out.println(name);
        System.out.println("Brand: "+ brand);
        System.out.println("Price: "+ price + "$");
        System.out.println("Scent: " + scent);
        System.out.println("Shade: " + shade);
        System.out.println("Texture: " + texture);
        System.out.println("brushType: " + brushType + "\n");
    }
}
