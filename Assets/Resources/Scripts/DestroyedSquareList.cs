using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroyedSquareList {
    private List<Vector2> destroyedSquarePositions;

    public DestroyedSquareList(int rows, int cols) {
        destroyedSquarePositions = new List<Vector2>(rows * cols);
    }
    public void addSquarePosition(Vector2 position) {
        destroyedSquarePositions.Add(position);
    }
    public List<Vector2> minRowsOfEachColumn() {
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
    public void clearList() {
        destroyedSquarePositions.Clear();
    }
}
