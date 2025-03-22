
using UnityEngine;

public class RegularInputState : GameplayState {
    private GameplayMouseInput mouseInput;

    public RegularInputState() {
        mouseInput = new GameplayMouseInput();
    }

    public override void updateState() {
        mouseInput.handleMouseInput();
    }
    public override bool exitConditionMet() {
        return mouseInput.squaresReleased;
    }
}
