using UnityEngine;

public class FreezeState : GameplayState {
    private int framesFrozen;
    private int framesLeft;

    public FreezeState(GameManager gameManager, int framesFrozen) : base(gameManager) {
        this.framesFrozen = framesFrozen;
    }

    public override void enterState() {
        framesLeft = framesFrozen;
    }
    public override void updateState() {
        framesLeft = framesLeft - 1;
    }
    public override bool exitConditionMet() {
        return framesLeft == 0;
    }
}
