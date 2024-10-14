using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // このクラスにグリッドへの参照を保存するだけで済む
    // 起動時にそれを見つけることができる
    // 静的プロパティ
    // 他のクラスから簡単にアクセスできるようにする
    public static Grid Grid { get; private set; }

    // 占有されているセルのリストを保持する静的プロパティ
    public static List<Vector2Int> OccupiedCells { get; private set; } = new List<Vector2Int>();

    // Awakeメソッドはオブジェクトの初期化時に呼び出される
    private void Awake()
    {
        // シーン内のGridコンポーネントを見つけて、Gridプロパティに設定する
        Grid = FindObjectOfType<Grid>();

        // OccupiedCellsリストをクリアする
        OccupiedCells.Clear();
    }

    void Start()
    {

    }

    void Update()
    {

    }
}

