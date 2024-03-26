public abstract class SkinCare extends Product{
    private String activeComponent;
    protected Boolean remove = false;
    protected SkinCare( String name, String brand, double price, String activeComponent, String scent) {
        super(name, brand, price , scent);
        this.activeComponent = activeComponent;
    }

    public void setRemove(Boolean remove) {
        this.remove = remove;
    }
}
