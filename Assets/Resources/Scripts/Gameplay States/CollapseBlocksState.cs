

public class CollapseBlocksState : GameplayState {
    private FallManager fallManager;
    private int fallers;
    private int completedFallers;

    public CollapseBlocksState(FallManager fallManager) {
        this.fallManager = fallManager;
    }

    public override void enterState() {
        fallManager.startFallersFalling();
    }
    public override bool exitConditionMet() {
        return !fallManager.fallersExist();
    }
}
