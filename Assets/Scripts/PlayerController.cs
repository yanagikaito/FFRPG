using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 移動に使う場合はグリッドへの参照が必要
    // グリッドプロパティ
    public Grid Grid { get; set; }

    // 移動しているときに設定する
    // グリッドを使用したい場合は必ずグリッドへの参照を取得する必要がある
    private void Awake()
    {
        Grid = FindObjectOfType<Grid>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3Int currentCell = Grid.WorldToCell(transform.position);
        transform.position = Grid.GetCellCenterWorld(currentCell);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }
        //// セルの中心をベクトル3として返す
        //Grid.GetCellCenterWorld();

        //// ベクトル3の位置を取得し,グリッド上のセルをベクトルとして返す
        //Grid.WorldToCell();
    }
}
