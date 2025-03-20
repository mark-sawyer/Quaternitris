using System.Collections.Generic;
using UnityEngine;

public static class SquareGridMaker {
    public static void exe(FallManager fallManager) {
        GameObject grid = GameObject.Find("grid");
        GameObject squarePrefab = Resources.Load<GameObject>("Prefabs/square");
        GameObject instantiated;
        List<Square> squares = new List<Square>(Constants.ROWS * Constants.COLS);

        for (int r = 0; r < 2 * Constants.ROWS; r++) {
            for (int c = 0; c < Constants.COLS; c++) {
                instantiated = GameObject.Instantiate(
                    squarePrefab,
                    new Vector3(c, r, 0f),
                    UnityEngine.Quaternion.identity,
                    grid.transform
                );
                instantiated.GetComponent<Square>().setup(fallManager);
                squares.Add(instantiated.GetComponent<Square>());
            }
        }
    }
}
