using UnityEngine;

public class GameplayMouseInput {
    /*
    private bool isHeld;
    private Square heldSquare;



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
            if (heldSquare != null) {
                heldSquare.holdReleased();
                heldSquare = null;
            }
        }  // Mouse pressed again while held (shouldn't happen)
        else if (Input.GetMouseButton(0)) {
            handleHeldHover(raycast);
        }
        else {
            isHeld = false;
            if (heldSquare != null) {
                heldSquare.holdReleased();
                heldSquare = null;
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
        Square holdable = raycast.collider.GetComponent<Square>();
        if (holdable == null) return;

        // The mouse was over a GridHoldable.
        holdable.beginBeingHeld();
        heldSquare = holdable;
    }
    private void handleHeldHover(RaycastHit2D raycast) {
        if (heldSquare == null) return;

        // There's a heldGridHoldable.
        if (raycast.collider == null) {
            heldSquare.heldHover();
            return;
        }

        // The mouse was over something with a collider.
        Square squareOver = raycast.collider.GetComponent<Square>();
        if (squareOver == null) {
            heldSquare.heldHover();
            return;
        }

        // The mouse was over a GridObject.
        heldSquare.heldHover(squareOver);
    }
    private void handleRelease(RaycastHit2D raycast) {
        if (heldSquare == null) return;

        // There's a heldGridHoldable.
        if (raycast.collider == null) {
            heldSquare.holdReleased();
            heldSquare = null;
            return;
        }

        // The mouse was over something with a collider.
        Square squareOver = raycast.collider.GetComponent<Square>();
        if (squareOver == null) {
            heldSquare.holdReleased();
            heldSquare = null;
            return;
        }

        // The mouse was over a GridObject.
        heldSquare.holdReleased(squareOver);
        heldSquare = null;
    }
    */
}
