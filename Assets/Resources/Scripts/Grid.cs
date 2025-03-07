using System.Collections.Generic;
using UnityEngine;

public class Grid {
    private GridObject[,] gridObjects;
    private int rows;
    private int cols;



    public Grid(Transform transform, int rows, int cols) {
        this.rows = rows;
        this.cols = cols;
        gridObjects = makeSquareGrid(transform);
        setNeighbourReferences();
    }



    private GridObject[,] makeSquareGrid(Transform transform) {
        float width = cols - 1;
        float height = rows - 1;
        float startX = -width / 2f;
        float startY = -height / 2f;
        GameObject squarePrefab = Resources.Load<GameObject>("Prefabs/square");
        GameObject instantiated;
        gridObjects = new GridObject[rows, cols];
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                instantiated = GameObject.Instantiate(
                    squarePrefab,
                    new Vector3(startX + c, startY + r, 0f),
                    UnityEngine.Quaternion.identity,
                    transform
                );
                gridObjects[r, c] = instantiated.GetComponent<GridObject>();
            }
        }
        return gridObjects;
    }
    private void setNeighbourReferences() {
        List<GridObject> neighbours;
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                neighbours = getNeighbours(r, c);
                gridObjects[r, c].GetComponent<Square>().setNeighbourReferences(neighbours);
            }
        }
    }
    private List<GridObject> getNeighbours(int r, int c) {
        List<GridObject> neighbours = new List<GridObject>();
        if (r > 0) neighbours.Add(gridObjects[r - 1, c]);
        if (r < rows - 1) neighbours.Add(gridObjects[r + 1, c]);
        if (c > 0) neighbours.Add(gridObjects[r, c - 1]);
        if (c < cols - 1) neighbours.Add(gridObjects[r, c + 1]);
        return neighbours;
    }
}
