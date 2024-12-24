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

    public void SetTileColor(Color c){
        spriteRenderer.color = c;
    }

    private void OnMouseEnter() {
        SetTileColor(Color.red);
    }

    private void OnMouseExit() {
        SetTileColor(Color.white);
    }

    private void OnMouseDown() {
        Debug.Log(HexPos);

        HexSlot[] test = transform.parent.GetComponent<HexBoard>().GetNeighbors(HexPos);

        transform.parent.GetComponent<HexBoard>().HighlightArray(test);
    }
}
