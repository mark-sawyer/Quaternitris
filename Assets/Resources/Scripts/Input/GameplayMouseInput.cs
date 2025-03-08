using UnityEngine;

public class GameplayMouseInput {
    private bool isHeld;
    private GridHoldable heldGridHoldable;



    public void handleMouseInput() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        RaycastHit2D raycast = Physics2D.Raycast(worldMousePos, Vector2.zero);
        if (isHeld) heldMouseActions(raycast);
        else unheldMouseActions(raycast);
    }



    private void heldMouseActions(RaycastHit2D raycast) {
        if (Input.GetMouseButtonUp(0)) {
            isHeld = false;
            handleRelease(raycast);
        }
        else if (Input.GetMouseButtonDown(0)) {
            if (heldGridHoldable != null) {
                heldGridHoldable.holdReleased();
                heldGridHoldable = null;
            }
        }  // Mouse pressed again while held (shouldn't happen)
        else if (Input.GetMouseButton(0)) {
            handleHeldHover(raycast);
        }
        else {
            isHeld = false;
            if (heldGridHoldable != null) {
                heldGridHoldable.holdReleased();
                heldGridHoldable = null;
            }
        }  // Mouse not held when held (shouldn't happen)
    }
    private void unheldMouseActions(RaycastHit2D raycast) {
        if (Input.GetMouseButtonDown(0)) {
            isHeld = true;
            handleClick(raycast);
        }
        else if (Input.GetMouseButton(0)) {
            isHeld = true;
        }  // Mouse held when not held (shouldn't happen)
    }
    private void handleClick(RaycastHit2D raycast) {
        if (raycast.collider == null) return;

        // The mouse was over something with a collider.
        GridHoldable holdable = raycast.collider.GetComponent<GridHoldable>();
        if (holdable == null) return;

        // The mouse was over a GridHoldable.
        holdable.beginBeingHeld();
        heldGridHoldable = holdable;
    }
    private void handleHeldHover(RaycastHit2D raycast) {
        if (heldGridHoldable == null) return;

        // There's a heldGridHoldable.
        if (raycast.collider == null) {
            heldGridHoldable.heldHover();
            return;
        }

        // The mouse was over something with a collider.
        GridObject gridObjectOver = raycast.collider.GetComponent<GridObject>();
        if (gridObjectOver == null) {
            heldGridHoldable.heldHover();
            return;
        }

        // The mouse was over a GridObject.
        heldGridHoldable.heldHover(gridObjectOver);
    }
    private void handleRelease(RaycastHit2D raycast) {
        if (heldGridHoldable == null) return;

        // There's a heldGridHoldable.
        if (raycast.collider == null) {
            heldGridHoldable.holdReleased();
            heldGridHoldable = null;
            return;
        }

        // The mouse was over something with a collider.
        GridObject gridObjectOver = raycast.collider.GetComponent<GridObject>();
        if (gridObjectOver == null) {
            heldGridHoldable.holdReleased();
            heldGridHoldable = null;
            return;
        }

        // The mouse was over a GridObject.
        heldGridHoldable.holdReleased(gridObjectOver);
        heldGridHoldable = null;
    }
}
