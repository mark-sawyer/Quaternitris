
public abstract class GameplayState {
    public GameplayState nextState { get; set; }
    public virtual void enterState() { }
    public virtual void updateState() { }
    public abstract bool exitConditionMet();
}
