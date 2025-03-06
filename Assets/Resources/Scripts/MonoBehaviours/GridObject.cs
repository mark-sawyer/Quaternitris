using System.Collections.Generic;
using UnityEngine;

public abstract class GridObject : MonoBehaviour {
    private List<GridObject> neighbours = new List<GridObject>();

    public void setNeighbourReferences(List<GridObject> neighbours) {
        this.neighbours = neighbours;
    }
    public bool inNeighbours(GridObject gridObject) {
        return neighbours.Contains(gridObject);
    }
}
