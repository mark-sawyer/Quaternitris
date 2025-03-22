using UnityEngine;

public class GameplayMouseInput {
    private Square clickedSquare;
    private Square hoveredSquare;
    private bool held;
    public bool squaresReleased { get; private set; }



    public void handleMouseInput() {
        squaresReleased = false;
        if (held) handleOn();
        else handleOff();
    }



    private void handleOn() {
        void handleNullNewHover() {
            if (hoveredSquare == null) return;

            if (hoveredSquare != clickedSquare) hoveredSquare.changeHighlightSetting(false);
            hoveredSquare = null;
        }
        void handleNonNullNewHover(Square newHoveredSquare) {
            if (hoveredSquare == null) {
                hoveredSquare = newHoveredSquare;
                newHoveredSquare.changeHighlightSetting(true);
            }
            else {
                if (hoveredSquare != clickedSquare) hoveredSquare.changeHighlightSetting(false);
                hoveredSquare = newHoveredSquare;
                hoveredSquare.changeHighlightSetting(true);
            }
        }

        if (!Input.GetMouseButton(0)) {
            held = false;
            if (clickedSquare != null) clickedSquare.changeHighlightSetting(false);
            if (hoveredSquare != null) hoveredSquare.changeHighlightSetting(false);
            if (clickedSquare != null && hoveredSquare != null) {
                clickedSquare.clickReleased(hoveredSquare);
                hoveredSquare.hoverReleased(clickedSquare);
                squaresReleased = true;
            }
            clickedSquare = null;
            hoveredSquare = null;
        }
        else if (clickedSquare != null) {
            Square newHoveredSquare = getMousedOverSquare();

            if (newHoveredSquare == null) handleNullNewHover();
            else handleNonNullNewHover(newHoveredSquare);
        }
    }
    private void handleOff() {
        if (Input.GetMouseButton(0)) {
            held = true;
            Square square = getMousedOverSquare();
            clickedSquare = square;
            hoveredSquare = square;
            if (square != null) square.changeHighlightSetting(true);
        }
    }
    private Square getMousedOverSquare() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        RaycastHit2D raycast = Physics2D.Raycast(worldMousePos, Vector2.zero);
        if (raycast.collider == null) return null;
        return raycast.collider.GetComponent<Square>();
    }
    /*
    private void heldMouseActions(RaycastHit2D raycast) {
        if (Input.GetMouseButtonUp(0)) {
            isHeld = false;
            handleRelease(raycast);
        }
        else if (Input.GetMouseButtonDown(0)) {
            if (clickedSquare != null) {
                clickedSquare.holdReleased();
                clickedSquare = null;
            }
        }  // Mouse pressed again while held (shouldn't happen)
        else if (Input.GetMouseButton(0)) {
            handleHeldHover(raycast);
        }
        else {
            isHeld = false;
            if (clickedSquare != null) {
                clickedSquare.holdReleased();
                clickedSquare = null;
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
        clickedSquare = holdable;
    }
    private void handleHeldHover(RaycastHit2D raycast) {
        if (clickedSquare == null) return;

        // There's a heldGridHoldable.
        if (raycast.collider == null) {
            clickedSquare.heldHover();
            return;
        }

        // The mouse was over something with a collider.
        Square squareOver = raycast.collider.GetComponent<Square>();
        if (squareOver == null) {
            clickedSquare.heldHover();
            return;
        }

        // The mouse was over a GridObject.
        clickedSquare.heldHover(squareOver);
    }
    private void handleRelease(RaycastHit2D raycast) {
        if (clickedSquare == null) return;

        // There's a heldGridHoldable.
        if (raycast.collider == null) {
            clickedSquare.holdReleased();
            clickedSquare = null;
            return;
        }

        // The mouse was over something with a collider.
        Square squareOver = raycast.collider.GetComponent<Square>();
        if (squareOver == null) {
            clickedSquare.holdReleased();
            clickedSquare = null;
            return;
        }

        // The mouse was over a GridObject.
        clickedSquare.holdReleased(squareOver);
        clickedSquare = null;
    }    
    */
}
