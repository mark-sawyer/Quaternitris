using UnityEngine;

public class Square : GridObject, GridHoldable {
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Quaternion quaternion;
    private GridObject hoveredNeighbourWhileThisHeld;



    private void Start() {
        quaternion = RandomQuaternion.exe();
        spriteRenderer.color = QuaternionColours.quaternionToColour(quaternion);
    }



    public override void gridObjectDelivered(GridObject gridObjectDraggedOn) {
        if (gridObjectDraggedOn is Square) {
            Square squareDraggedOn = (Square)gridObjectDraggedOn;
            quaternion = squareDraggedOn.quaternion.transform(quaternion);
            spriteRenderer.color = QuaternionColours.quaternionToColour(quaternion);
        }
    }



    public void beginBeingHeld() {
        changeHighlightSetting(true);
    }
    public void heldHover() {
        if (hoveredNeighbourWhileThisHeld == null) return;

        hoveredNeighbourWhileThisHeld.changeHighlightSetting(false);
        hoveredNeighbourWhileThisHeld = null;
    }
    public void heldHover(GridObject gridObjectOver) {
        void noCurrentNeighbourBeingHovered() {
            if (!isNeighbour(gridObjectOver)) return;

            hoveredNeighbourWhileThisHeld = gridObjectOver;
            hoveredNeighbourWhileThisHeld.changeHighlightSetting(true);
        }
        void currentNeighbourIsBeingHovered() {
            if (!isNeighbour(gridObjectOver)) {
                hoveredNeighbourWhileThisHeld.changeHighlightSetting(false);
                hoveredNeighbourWhileThisHeld = null;
                return;
            }

            if (gridObjectOver == hoveredNeighbourWhileThisHeld) return;

            hoveredNeighbourWhileThisHeld.changeHighlightSetting(false);
            hoveredNeighbourWhileThisHeld = gridObjectOver;
            hoveredNeighbourWhileThisHeld.changeHighlightSetting(true);
        }

        if (hoveredNeighbourWhileThisHeld == null) noCurrentNeighbourBeingHovered();
        else currentNeighbourIsBeingHovered();
    }
    public void holdReleased() {
        if (hoveredNeighbourWhileThisHeld != null) {
            // Don't think this should ever run.
            hoveredNeighbourWhileThisHeld.changeHighlightSetting(false);
            hoveredNeighbourWhileThisHeld = null;
        }
        changeHighlightSetting(false);
    }
    public void holdReleased(GridObject gridObjectOver) {
        changeHighlightSetting(false);

        if (hoveredNeighbourWhileThisHeld == null) return;

        hoveredNeighbourWhileThisHeld.changeHighlightSetting(false);
        hoveredNeighbourWhileThisHeld.gridObjectDelivered(this);
        Destroy(gameObject);
    }
}
