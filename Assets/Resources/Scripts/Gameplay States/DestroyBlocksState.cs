using UnityEngine;

public class DestroyBlocksState : GameplayState {
    private FallManager fallManager;

    public DestroyBlocksState(FallManager fallManager) {
        this.fallManager = fallManager;
    }
    public override void enterState() {
        fallManager.clearDestroyedPositionsList();
        Events.destroyHighlightedSquares.Invoke();
    }
    public override bool exitConditionMet() {
        return true;
    }
}
