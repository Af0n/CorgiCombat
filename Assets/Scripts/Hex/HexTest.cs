using UnityEngine;

public class HexTest : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        TestSimpleHex();
    }

    public void TestSimpleHex(){
        for(int x=-1; x<2; x++){
            for(int y=-1; y<2; y++){
                for(int z=-1; z<2; z++){
                    GameObject obj = Instantiate(prefab);
                    obj.GetComponent<HexSlot>().SetHexPos(x, y, z);
                }
            }
        }
    }
}
