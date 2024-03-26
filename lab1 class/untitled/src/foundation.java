public class foundation extends DecorativeCosmetics{
    private final String coverage;
    private final String finish;

    public foundation(String name, String brand, double price, String coverage,  String finish, String scent, int shade, String texture) {
        super(name, brand, price,  shade, scent, texture);
        this.coverage=coverage;
        this.finish = finish;
    }
    public String getCoverage(){return coverage;}
    public String getFinish(){return finish;}
    @Override
    public void printinfo() {
        System.out.println(name);
        System.out.println("Brand: "+ brand);
        System.out.println("Price: "+ price+ "$");
        System.out.println("Coverage: " + coverage);
        System.out.println("Finish: " + finish);
        System.out.println("Scent: " + scent);
        System.out.println("Shade: " + shade);
        System.out.println("Texture: " + texture + "\n");
    }

}
