using UnityEngine;

public static class SquareGetter {
    public static Square exe(float x, float y) {
        int layerMask = ~LayerMask.GetMask("sprite mask");
        Vector3 pos = new Vector3(x, y);
        RaycastHit2D raycast = Physics2D.Raycast(pos, Vector3.zero, 0f, layerMask);
        if (raycast.collider == null) return null;
        else return raycast.collider.GetComponent<Square>();
    }
}
