public class Serum extends SkinCare {
    private boolean hyppoallergenic;
    private String speedOfAction;
    protected Serum(String name, String brand,  double price, String activeComponent, String scent, boolean hyppoallergenic, String speedOfAction ) {
        super (name, brand,price, activeComponent, scent);
        this.hyppoallergenic = hyppoallergenic;
        this.speedOfAction = speedOfAction;
    }


    @Override
    public void printinfo() {
        System.out.println(name);
        System.out.println("Brand: "+ brand);
        System.out.println("Price: "+ price + "$ ");
        System.out.println("Speed of action: " + speedOfAction);
        System.out.println("Scent: " + scent);
        if (hyppoallergenic ){
            System.out.println("Hyppoallergetic \n");}
        else {
            System.out.println("");
        }
    }
}
