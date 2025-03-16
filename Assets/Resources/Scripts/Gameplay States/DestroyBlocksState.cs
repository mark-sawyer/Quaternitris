using UnityEngine;

public class DestroyBlocksState : GameplayState {
    public DestroyBlocksState(GameManager gameManager) : base(gameManager) { }

    public override void enterState() { }
    public override void updateState() {
        Events.destroyHighlightedSquares.Invoke();
    }
    public override bool exitConditionMet() {
        return true;
    }
}
