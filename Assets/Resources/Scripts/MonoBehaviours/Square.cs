using System;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {
    [SerializeField] private SpriteRenderer spriteRenderer;
    private FallManager fallManager;
    private Quaternion quaternion;
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



    public void setup(FallManager fallManager) {
        this.fallManager = fallManager;
    }
    public void changeHighlightSetting(bool b) {
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = b;
    }
    public void startFalling() {
        update = updateFall;
    }
    public bool checkFalling() {
        return falling;
    }
    public void clickReleased(Square hover) {
        changeHighlightSetting(true);
    }
    public void hoverReleased(Square click) {
        changeHighlightSetting(true);
    }



    private void updateFall() {
        if (falling) {
            Square squareBelow = getSquareBelow();
            if (cannotFallFurther(squareBelow)) {
                falling = false;
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
    private bool cannotFallFurther(Square squareBelow) {
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
            fallManager.addDestroyedPosition(transform.position);
            Destroy(gameObject);
        }
    }
}
