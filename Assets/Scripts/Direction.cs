using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Direction
{
    // 4つの方向をそれぞれ参照する。
    // Upはベクトル2は01
    public static readonly Vector2Int Up = new Vector2Int(0, 1);
    public static readonly Vector2Int Down = new Vector2Int(0, -1);
    public static readonly Vector2Int Left = new Vector2Int(-1, 0);
    public static readonly Vector2Int Right = new Vector2Int(1, 0);
}
