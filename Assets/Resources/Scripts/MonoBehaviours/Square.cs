using System.Collections.Generic;
using UnityEngine;

public class Square : GridObject, GridHoldable {
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Quaternion quaternion;



    private void Start() {
        quaternion = RandomQuaternion.exe();
        spriteRenderer.color = QuaternionColours.quaternionToColour(quaternion);
    }



    public void beginBeingHeld() {
        print("hold began for " + quaternion.sign.ToString() + " " + quaternion.dimension.ToString() + " square");
    }
    public void holdReleased() {
        print("hold ended for " + quaternion.sign.ToString() + " " + quaternion.dimension.ToString() + " square");
    }
    public void holdReleased(GridObject gridObjectOver) {
        print(
            quaternion.sign.ToString() + " " + quaternion.dimension.ToString() + " square was delivered a " +
            ((Square)gridObjectOver).quaternion.sign.ToString() + " " +
            ((Square)gridObjectOver).quaternion.dimension.ToString() + " square"
        );
    }
    public void heldHover(GridObject hoveredOver) {
        print(
            "over a " +
            ((Square)hoveredOver).quaternion.sign.ToString() + " " +
            ((Square)hoveredOver).quaternion.dimension.ToString() + " square"
        );
    }
}
