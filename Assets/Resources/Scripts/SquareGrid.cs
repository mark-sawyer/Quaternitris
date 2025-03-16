using System.Collections.Generic;
using UnityEngine;

public class SquareGrid {
    private List<Square> squares;
    private int rows;
    private int cols;



    public SquareGrid(int rows, int cols, DestroyedSquareList destroyedSquareList, CollapseBlocksState collapseBlocksState) {
        this.rows = 2 * rows;
        this.cols = cols;
        squares = makeSquareGrid(destroyedSquareList, collapseBlocksState);
    }



    private List<Square> makeSquareGrid(DestroyedSquareList destroyedSquareList, CollapseBlocksState collapseBlocksState) {
        GameObject grid = new GameObject("grid");
        GameObject squarePrefab = Resources.Load<GameObject>("Prefabs/square");
        GameObject instantiated;
        squares = new List<Square>(rows * cols);

        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                instantiated = GameObject.Instantiate(
                    squarePrefab,
                    new Vector3(c, r, 0f),
                    UnityEngine.Quaternion.identity,
                    grid.transform
                );
                instantiated.GetComponent<Square>().setup(destroyedSquareList, collapseBlocksState);
                squares.Add(instantiated.GetComponent<Square>());
            }
        }

        return squares;
    }
}
