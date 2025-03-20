
public class ReplaceBlocksState : GameplayState {
    private FallManager fallManager;
    
    public ReplaceBlocksState(FallManager fallManager) {
        this.fallManager = fallManager;
    }
    public override void enterState() {
        fallManager.replaceDestroyedBlocks();
    }
    public override bool exitConditionMet() {
        return true;
    }
}
