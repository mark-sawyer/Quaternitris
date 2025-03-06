using UnityEngine;

public class GameManager : MonoBehaviour {
    private GameplayMouseInput mouseInput;

    private void Start() {
        mouseInput = new GameplayMouseInput();
        Grid squareGridCreator = new Grid(transform, 8, 15);
    }

    private void Update() {
        mouseInput.handleMouseInput();
    }
}
