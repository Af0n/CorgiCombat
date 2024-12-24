using Unity.VisualScripting;
using UnityEngine;

public class HexBoard : MonoBehaviour
{
    [Header("Size")]
    public int Rows;
    public int Cols;
    [Header("Uniy Set Up")]
    public GameObject SlotPrefab;

    private HexSlot[,] board;

    private void Awake() {
        InitBoard(Rows, Cols);
    }

    public void InitBoard(int _rows, int _cols){
        Rows = _rows;
        Cols = _cols;

        BuildBoard();
    }

    private void BuildBoard(){
        board =  new HexSlot[Rows, Cols];

        for(int i=0; i<Rows; i++){
            for(int n=0; n<Cols; n++){
                GameObject obj = Instantiate(SlotPrefab, transform);
                obj.GetComponent<HexSlot>().SetHexPos(i, n);

                board[i, n] = obj.GetComponent<HexSlot>();
            }
        }
    }

    public HexSlot GetAt(int x, int y){
        // checking if coords in range

        if(x < 0 || x >= Rows){
            return null;
        }

        if(y < 0 || y >= Cols){
            return null;
        }

        return board[x, y];
    }

    public HexSlot[] GetNeighbors(int x, int y){
        HexSlot[] result = new HexSlot[6];

        result[0] = GetAt(x, y-1);
        result[1] = GetAt(x, y+1);
        result[2] = GetAt(x-1, y);
        result[3] = GetAt(x+1, y);

        if(y%2 == 0){
            result[4] = GetAt(x-1, y+1);
            result[5] = GetAt(x-1, y-1);
        }else{
            result[4] = GetAt(x+1, y+1);
            result[5] = GetAt(x+1, y-1);
        }

        return result;
    }

    public HexSlot[] GetNeighbors(Vector2 hexPos){
        HexSlot[] result = new HexSlot[6];

        int row = (int)hexPos.x;
        int col = (int)hexPos.y;

        return GetNeighbors(row, col);
    }

    public void HighlightArray(HexSlot[] list){
        foreach (HexSlot hexSlot in list)
        {
            if(hexSlot == null){
                continue;
            }

            hexSlot.SetTileColor(Color.yellow);
        }
    }
}
