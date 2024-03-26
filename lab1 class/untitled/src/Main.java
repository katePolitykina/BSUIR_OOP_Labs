import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<Product> cosmetics = new ArrayList<>();
        cosmetics.add(new foundation( "foundation","Dior", 59.99,  "Light", "Natural", "Rose", 1, "liquid" ));
        cosmetics.add(new foundation( "foundation","Fenty Beauty", 33.95,  "Full", "Matte", "None", 5, "pouder" ));
        cosmetics.add(new Mascara("mascara","Rare Beauty", 14.95, 1, "None", "liquid", "Hourglass (volume)"));
        cosmetics.add(new Serum("serum","Ordinary",14, "Niainaide", "coconut", false, "1 mounth"));
        cosmetics.add(new Mask("mask", "Garnier", 3.49, "Hyalyronic Acid", "none", 20, "Sheet mask" , false));

        for (Product cosm :cosmetics) {
            cosm.printinfo();
        }
    }
}