using System;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {
    [SerializeField] private SpriteRenderer spriteRenderer;
    private DestroyedSquareList destroyedSquareList;
    private CollapseBlocksState collapseBlocksState;
    private Quaternion quaternion;
    private Square hoveredNeighbourWhileThisHeld;
    private Action update;
    private bool falling;



    private void Start() {
        quaternion = RandomQuaternion.exe();
        spriteRenderer.color = QuaternionColours.quaternionToColour(quaternion);
        Events.destroyHighlightedSquares.AddListener(breakSquare);
        update = () => { };
    }
    private void Update() {
        update();
    }


    public void setup(DestroyedSquareList destroyedSquareList, CollapseBlocksState collapseBlocksState) {
        this.destroyedSquareList = destroyedSquareList;
        this.collapseBlocksState = collapseBlocksState;
    }
    public void changeHighlightSetting(bool b) {
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = b;
    }
    public void startFalling() {
        update = updateFall;
    }



    private void updateFall() {
        if (falling) {
            Square squareBelow = getSquareBelow();
            if (stopped(squareBelow)) {
                falling = false;
                collapseBlocksState.fallCompleted();
                update = () => { };
            }
            else fall();
        }
        else {
            Square squareBelow = getSquareBelow();
            if (squareBelow == null) falling = true;
            else {
                float dist = distanceToSquareBelow(squareBelow);
                if (dist > 1f) falling = true;
            }
        }
    }
    private void fall() {
        transform.position = transform.position + new Vector3(0f, -1f / 8f);
    }
    private bool stopped(Square squareBelow) {
        if (squareBelow == null) return transform.position.y == 0f;
        else {
            float dist = distanceToSquareBelow(squareBelow);
            return dist <= 1f;
        }
    }
    private Square getSquareBelow() {
        return SquareGetter.exe(transform.position.x, transform.position.y - 1f);
    }
    private float distanceToSquareBelow(Square squareBelow) {
        return transform.position.y - squareBelow.transform.position.y;
    }
    private void breakSquare() {
        if (transform.GetChild(0).GetComponent<SpriteRenderer>().enabled) {
            destroyedSquareList.addSquarePosition(transform.position);
            Destroy(gameObject);
        }
    }



    /*
    public Square getNeigbour(Vector3 dir) {
        Vector3 worldPos = transform.position + dir;
        RaycastHit2D raycast = Physics2D.Raycast(worldPos, Vector2.zero);
        if (raycast.collider == null) return null;
        Square square = raycast.collider.GetComponent<Square>();
        return square;
    }
    public void gridObjectDelivered(Square squareDraggedOn) {
        quaternion = squareDraggedOn.quaternion.transform(quaternion);
        spriteRenderer.color = QuaternionColours.quaternionToColour(quaternion);
    }
    public void beginBeingHeld() {
        changeHighlightSetting(true);
    }
    public void heldHover() {
        if (hoveredNeighbourWhileThisHeld == null) return;

        hoveredNeighbourWhileThisHeld.changeHighlightSetting(false);
        hoveredNeighbourWhileThisHeld = null;
    }
    public void heldHover(Square squareOver) {
        void noCurrentNeighbourBeingHovered() {
            if (!neighbours.Contains(squareOver)) return;

            hoveredNeighbourWhileThisHeld = squareOver;
            hoveredNeighbourWhileThisHeld.changeHighlightSetting(true);
        }
        void currentNeighbourIsBeingHovered() {
            if (!neighbours.Contains(squareOver)) {
                hoveredNeighbourWhileThisHeld.changeHighlightSetting(false);
                hoveredNeighbourWhileThisHeld = null;
                return;
            }

            if (squareOver == hoveredNeighbourWhileThisHeld) return;

            hoveredNeighbourWhileThisHeld.changeHighlightSetting(false);
            hoveredNeighbourWhileThisHeld = squareOver;
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
    public void holdReleased(Square squareOver) {
        changeHighlightSetting(false);

        if (hoveredNeighbourWhileThisHeld == null) return;

        hoveredNeighbourWhileThisHeld.changeHighlightSetting(false);
        hoveredNeighbourWhileThisHeld.gridObjectDelivered(this);
        Destroy(gameObject);
    }
    */
}
