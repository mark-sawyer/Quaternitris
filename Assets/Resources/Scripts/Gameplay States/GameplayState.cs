
public abstract class GameplayState {
    protected GameManager gameManager;
    public GameplayState nextState { get; private set; }



    public GameplayState(GameManager gameManager) {
        this.gameManager = gameManager;
    }
    public void setNextState(GameplayState nextState) {
        this.nextState = nextState;
    }



    public abstract void enterState();
    public abstract void updateState();
    public abstract bool exitConditionMet();
}
