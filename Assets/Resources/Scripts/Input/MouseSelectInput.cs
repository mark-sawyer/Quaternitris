
using UnityEngine;

public class MouseSelectInput {
    public void handleMouseInput() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            RaycastHit2D raycast = Physics2D.Raycast(worldMousePos, Vector2.zero);
            if (raycast.collider == null) return;
            Square square = raycast.collider.GetComponent<Square>();
            if (square == null) return;
            square.changeHighlightSetting(true);
        }
    }
}
