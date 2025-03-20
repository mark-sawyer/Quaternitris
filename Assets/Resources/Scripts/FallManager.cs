
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FallManager {
    private List<Vector2> destroyedSquarePositions;
    private List<Square> fallingSquares;
    private GameObject squarePrefab;
    private GameObject grid;



    public FallManager() {
        destroyedSquarePositions = new List<Vector2>();
        grid = GameObject.Find("grid");
        squarePrefab = Resources.Load<GameObject>("Prefabs/square");
    }
    public void clearDestroyedPositionsList() {
        destroyedSquarePositions.Clear();
    }
    public void addDestroyedPosition(Vector2 position) {
        destroyedSquarePositions.Add(position);
    }
    public void startFallersFalling() {
        fallingSquares = getFallingSquares();
        foreach (Square square in fallingSquares) {
            square.startFalling();
        }
    }
    public bool fallersExist() {
        return fallingSquares.Exists(s => s.checkFalling());
    }
    public void replaceDestroyedBlocks() {
        GameObject instantiated;
        for (float r = Constants.ROWS; r < 2f * Constants.ROWS; r++) {
            for (float c = 0; c < Constants.COLS; c++) {
                Square square = SquareGetter.exe(c, r);
                if (square == null) {
                    instantiated = GameObject.Instantiate(
                        squarePrefab,
                        new Vector3(c, r, 0f),
                        UnityEngine.Quaternion.identity,
                        grid.transform
                    );
                    instantiated.GetComponent<Square>().setup(this);
                }
            }
        }
    }



    private List<Square> getFallingSquares() {
        List<Vector2> minRowsOfEachColumn() {
            List<Vector2> minList = new List<Vector2>();
            foreach (Vector2 pos in destroyedSquarePositions) {
                if (minList.Any(v => v.x == pos.x)) {
                    int index = minList.FindIndex(v => v.x == pos.x);
                    float currentMinY = minList[index].y;
                    if (pos.y < currentMinY) { minList[index] = pos; }
                }
                else minList.Add(pos);
            }
            return minList;
        }
        List<Square> newFallingSquaresList = new List<Square>();
        List<Vector2> lowestEmptyPosForEachColumn = minRowsOfEachColumn();
        foreach (Vector2 v in lowestEmptyPosForEachColumn) {
            for (float y = v.y + 1; y < 2 * Constants.ROWS; y++) {
                Square square = SquareGetter.exe(v.x, y);
                if (square != null) newFallingSquaresList.Add(square);
            }
        }
        return newFallingSquaresList;
    }
}
