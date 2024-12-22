using Unity.Collections;
using UnityEngine;

public class HexSlot : MonoBehaviour
{
    // x: - left, + right
    // y: - top left, + bottom right
    // z: - bottom left, + top right
    public Vector3 hexPos;
    private Vector3 worldPos;

    public static Vector3 HexPosToWorldPos(Vector3 hex){
        float x = hex.x + (hex.y * 0.5f) + (hex.z * 0.5f);
        float y = hex.y - (hex.y * 0.5f) + (hex.z * 0.5f);
        return new Vector3(x, y, 0f);
    }

    private void Awake() {
        worldPos = HexPosToWorldPos(hexPos);
        transform.position = worldPos;
    }
}
