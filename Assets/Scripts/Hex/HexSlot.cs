using Unity.Collections;
using UnityEditor.ShaderGraph.Internal;
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
        float y = (hex.y * -0.75f) + (hex.z * 0.75f);
        return new Vector3(x, y, 0f);
    }

    private void Awake() {
        worldPos = HexPosToWorldPos(hexPos);
        transform.position = worldPos;
    }

    public void SetHexPos(float x, float y, float z){
        hexPos.x = x;
        hexPos.y = y;
        hexPos.z = z;

        worldPos = HexPosToWorldPos(hexPos);
        transform.position = worldPos;
    }
}
