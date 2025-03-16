using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMasker {
    public SquareMasker(int rows, int cols) {
        GameObject maskPrefab = Resources.Load<GameObject>("Prefabs/square_mask");
        float startY = rows;
        GameObject instantiated = GameObject.Instantiate(
            maskPrefab,
            new Vector3((cols - 1f) / 2f, 1.5f * rows, -1f),
            UnityEngine.Quaternion.identity
        );
        instantiated.transform.localScale = new Vector3(cols + 2, rows + 1, 1);
        instantiated.name = "square_mask";
    }
}
