using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMasker {
    public SquareMasker() {
        GameObject maskPrefab = Resources.Load<GameObject>("Prefabs/square_mask");
        float startY = Constants.ROWS;
        GameObject instantiated = GameObject.Instantiate(
            maskPrefab,
            new Vector3((Constants.COLS - 1f) / 2f, 1.5f * Constants.ROWS, -1f),
            UnityEngine.Quaternion.identity
        );
        instantiated.transform.localScale = new Vector3(Constants.COLS + 2, Constants.ROWS + 1, 1);
        instantiated.name = "square_mask";
    }
}
