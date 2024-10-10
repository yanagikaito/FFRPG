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

    private void Awake()
    {
        Grid = FindObjectOfType<Grid>();
    }

    void Start()
    {

    }


    void Update()
    {

    }
}
