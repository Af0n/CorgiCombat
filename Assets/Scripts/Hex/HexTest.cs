using UnityEngine;

public class HexTest : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        TestSimpleHex();
    }

    public void TestSimpleHex(){
        for(int x=-2; x<3; x++){
            for(int y=-2; y<3; y++){
                GameObject obj = Instantiate(prefab);
                obj.GetComponent<HexSlot>().SetHexPos(x, y);
            }
        }
    }
}
