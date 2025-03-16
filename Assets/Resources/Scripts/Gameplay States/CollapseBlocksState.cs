
using System.Collections.Generic;
using UnityEngine;

public class CollapseBlocksState : GameplayState {
    private DestroyedSquareList destroyedSquareList;
    private int rows;
    private int fallers;
    private int completedFallers;

    public CollapseBlocksState(GameManager gameManager, DestroyedSquareList destroyedSquareList, int rows) : base(gameManager) {
        this.destroyedSquareList = destroyedSquareList;
        this.rows = 2 * rows;
    }

    public override void enterState() {
        fallers = 0;
        completedFallers = 0;
        List<Vector2> lowestDestroyedPositionForEachColumn = destroyedSquareList.minRowsOfEachColumn();
        destroyedSquareList.clearList();
        foreach (Vector2 v in lowestDestroyedPositionForEachColumn) {
            for (float y = v.y + 1; y < rows; y++) {
                Square square = SquareGetter.exe(v.x, y);
                if (square != null) {
                    square.startFalling();
                    fallers++;
                }
            }            
        }
    }
    public override void updateState() { }
    public override bool exitConditionMet() {
        return completedFallers == fallers;
    }

    public void fallCompleted() {
        completedFallers++;
    }
}
