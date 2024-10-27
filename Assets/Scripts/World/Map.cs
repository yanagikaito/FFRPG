using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // 占有されているセルのリストを保持する静的プロパティ
    public Dictionary<Vector2Int, MonoBehaviour> OccupiedCells { get; private set; } = new Dictionary<Vector2Int, MonoBehaviour>();

    // このクラスにグリッドへの参照を保存するだけで済む
    // 起動時にそれを見つけることができる
    // 他のクラスから簡単にアクセスできるようにする
    public Grid Grid { get; private set; }

    // Awakeメソッドはオブジェクトの初期化時に呼び出される
    private void Awake()
    {
        // シーン内のGridコンポーネントを見つけて、Gridプロパティに設定する
        Grid = GetComponent<Grid>();

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

