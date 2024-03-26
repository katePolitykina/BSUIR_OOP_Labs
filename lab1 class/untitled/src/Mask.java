public class Mask extends SkinCare{
    private int time;
    private String maskType;
    private boolean removable ;
    protected Mask( String name, String brand, double price, String activeComponent, String scent, int time, String maskType, boolean removable) {
        super( name, brand, price, activeComponent, scent);
        this.maskType=maskType;
        this.time = time;
        this.removable = removable;
    }

    public void remove(){
        System.out.println("Removing " + name + " ...");
    };
    @Override
    public void printinfo() {
        System.out.println(name);
        System.out.println("Brand: "+ brand);
        System.out.println("Price: "+ price + "$ ");
        System.out.println("Type: " + maskType);
        System.out.println("Scent: " + scent);
        System.out.println("Apply for " + time + " minutes");
        if (removable ){
            System.out.println("Wash your face with worm water after \n");}
        else {
            System.out.println("");
        }

    }
}
