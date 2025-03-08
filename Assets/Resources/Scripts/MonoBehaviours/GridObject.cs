using System.Collections.Generic;
using UnityEngine;

public abstract class GridObject : MonoBehaviour {
    private List<GridObject> neighbours = new List<GridObject>();

    public void setNeighbourReferences(List<GridObject> neighbours) {
        this.neighbours = neighbours;
    }
    public bool isNeighbour(GridObject gridObject) {
        return neighbours.Contains(gridObject);
    }
    public int getNeighbourCount() {
        return neighbours.Count;
    }
    public abstract void gridObjectDelivered(GridObject gridObjectDraggedOn);



    protected internal void changeHighlightSetting(bool b) {
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = b;
    }
}
