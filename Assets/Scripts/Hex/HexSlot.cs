using UnityEngine;

public class HexSlot : MonoBehaviour
{
    public Vector2 HexPos;

    private SpriteRenderer spriteRenderer;
    private Vector3 worldPos;

    public static Vector3 HexPosToWorldPos(Vector3 hex){
        float x = hex.x + Mathf.Abs((hex.y % 2)/2);
        float y = hex.y * 0.75f;
        return new Vector3(x, y, 0f);
    }

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();

        worldPos = HexPosToWorldPos(HexPos);
        transform.position = worldPos;
    }

    public void SetHexPos(float x, float y){
        HexPos.x = x;
        HexPos.y = y;

        worldPos = HexPosToWorldPos(HexPos);
        transform.position = worldPos;
    }

    private void OnMouseEnter() {
        spriteRenderer.color = Color.red;
    }

    private void OnMouseExit() {
        spriteRenderer.color = Color.white;
    }

    private void OnMouseDown() {
        Debug.Log(HexPos);
    }
}
