using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Vector2Int currentCell = Map.Grid.GetCell2D(this.gameObject);
        transform.position = Map.Grid.GetCellCenterWorld((Vector3Int)currentCell);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2Int currentCell = Map.Grid.GetCell2D(this.gameObject);

            // Vector3IntとVector2Intは異なる型であり、直接加算することはできない
            transform.position = Map.Grid.GetCellCenterWorld((Vector3Int)(currentCell + Direction.Left));
        }
        //// セルの中心をベクトル3として返す
        //Grid.GetCellCenterWorld();

        //// ベクトル3の位置を取得し,グリッド上のセルをベクトルとして返す
        //Grid.WorldToCell();
    }
}
