
public interface GridHoldable {
    public void beginBeingHeld();
    public void holdReleased();
    public void holdReleased(GridObject releasedOn);
    public void heldHover();
    public void heldHover(GridObject hoveredOver);
}
