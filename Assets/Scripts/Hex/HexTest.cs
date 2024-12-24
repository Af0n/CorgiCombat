using UnityEngine;

public class HexTest : MonoBehaviour
{
    public HexBoard testItem;

    void Start()
    {
        Debug.Log(testItem.GetNeighbors(0,0));
    }
}
