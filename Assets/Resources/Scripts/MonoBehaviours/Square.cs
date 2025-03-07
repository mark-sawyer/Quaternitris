using UnityEngine;

public class Square : GridObject, GridHoldable {
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Quaternion quaternion;
    private GridObject hoveredNeighbourWhileThisHeld;



    private void Start() {
        quaternion = RandomQuaternion.exe();
        spriteRenderer.color = QuaternionColours.quaternionToColour(quaternion);
    }



    public void beginBeingHeld() {
        changeHighlightSetting(true);
    }
    public void heldHover(GridObject hoveredOver) {
        void noCurrentNeighbourBeingHovered() {
            if (!isNeighbour(hoveredOver)) return;

            hoveredNeighbourWhileThisHeld = hoveredOver;
            hoveredNeighbourWhileThisHeld.changeHighlightSetting(true);
        }
        void currentNeighbourIsBeingHovered() {
            if (!isNeighbour(hoveredOver)) {
                hoveredNeighbourWhileThisHeld.changeHighlightSetting(false);
                hoveredNeighbourWhileThisHeld = null;
                return;
            }

            if (hoveredOver == hoveredNeighbourWhileThisHeld) return;

            hoveredNeighbourWhileThisHeld.changeHighlightSetting(false);
            hoveredNeighbourWhileThisHeld = hoveredOver;
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
        if (hoveredNeighbourWhileThisHeld != null) {
            hoveredNeighbourWhileThisHeld.changeHighlightSetting(false);
            hoveredNeighbourWhileThisHeld = null;
        }
        changeHighlightSetting(false);
    }
}
