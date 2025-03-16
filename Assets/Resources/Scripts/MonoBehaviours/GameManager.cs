using UnityEngine;

public class GameManager : MonoBehaviour {
    private GameplayState gameplayState;
    private RegularInputState regularInputState;
    private FreezeState freezeState;
    private DestroyBlocksState destroyBlocksState;
    private CollapseBlocksState collapseBlocksState;



    private void Start() {
        int rows = 8;
        int cols = 4;
        Camera.main.transform.position = new Vector3((cols - 1f) / 2f, (rows - 1f) / 2f, -10f);
        DestroyedSquareList destroyedSquareList = new DestroyedSquareList(rows, cols);
        setupStates(destroyedSquareList, rows);
        SquareGrid squareGridCreator = new SquareGrid(rows, cols, destroyedSquareList, collapseBlocksState);
        SquareMasker squareMasker = new SquareMasker(rows, cols);
    }
    private void Update() {
        gameplayState.updateState();
        if (gameplayState.exitConditionMet()) {
            gameplayState = gameplayState.nextState;
            gameplayState.enterState();
        }
    }
    private void setupStates(DestroyedSquareList destroyedSquareList, int rows) {
        regularInputState = new RegularInputState(this);
        freezeState = new FreezeState(this, 2);
        destroyBlocksState = new DestroyBlocksState(this);
        collapseBlocksState = new CollapseBlocksState(this, destroyedSquareList, rows);

        regularInputState.setNextState(freezeState);
        freezeState.setNextState(destroyBlocksState);
        destroyBlocksState.setNextState(collapseBlocksState);
        collapseBlocksState.setNextState(regularInputState);

        gameplayState = regularInputState;
    }
}
