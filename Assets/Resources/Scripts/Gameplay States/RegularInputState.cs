
using Unity.VisualScripting;
using UnityEngine;

public class RegularInputState : GameplayState {
    private MouseSelectInput mouseInput;

    public RegularInputState(GameManager gameManager) : base(gameManager) {
        mouseInput = new MouseSelectInput();
    }

    public override void enterState() { }
    public override void updateState() {
        Debug.Log("regular degular");
        mouseInput.handleMouseInput();
    }
    public override bool exitConditionMet() {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
