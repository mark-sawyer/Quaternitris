using UnityEngine;

public class GameManager : MonoBehaviour {
    private GameplayState gameplayState;
    private RegularInputState regularInputState;
    private FreezeState freezeState;
    private DestroyBlocksState destroyBlocksState;
    private CollapseBlocksState collapseBlocksState;
    private ReplaceBlocksState replaceBlocksState;



    private void Start() {
        Camera.main.transform.position = getCameraPosition();
        FallManager fallManager = new FallManager();
        setupStates(fallManager);
        SquareGridMaker.exe(fallManager);
        SquareMasker squareMasker = new SquareMasker();
    }
    private void Update() {
        gameplayState.updateState();
        if (gameplayState.exitConditionMet()) {
            gameplayState = gameplayState.nextState;
            gameplayState.enterState();
        }
    }
    private void setupStates(FallManager fallManager) {
        regularInputState = new RegularInputState();
        freezeState = new FreezeState(2);
        destroyBlocksState = new DestroyBlocksState(fallManager);
        collapseBlocksState = new CollapseBlocksState(fallManager);
        replaceBlocksState = new ReplaceBlocksState(fallManager);

        regularInputState.nextState = freezeState;
        freezeState.nextState = destroyBlocksState;
        destroyBlocksState.nextState = collapseBlocksState;
        collapseBlocksState.nextState = replaceBlocksState;
        replaceBlocksState.nextState = regularInputState;

        gameplayState = regularInputState;
    }
    private Vector3 getCameraPosition() {
        return new Vector3(
                (Constants.COLS - 1f) / 2f,
                (Constants.ROWS - 1f) / 2f, -10f
            );
    }
}
