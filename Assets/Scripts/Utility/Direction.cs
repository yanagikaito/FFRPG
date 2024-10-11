using UnityEngine;

public static class Direction
{
    public static readonly Vector2Int Up = new(0, 1);
    public static readonly Vector2Int Down = new(0, -1);
    public static readonly Vector2Int Left = new(-1, 0);
    public static readonly Vector2Int Right = new(1, 0);

    // Vector2Int型の方向がUp、Down、Left、Rightのいずれかであるかを確認
    // 基本的な方向であればtrueを返し、それ以外ならfalseを返す
    public static bool IsBasic(this Vector2Int direction)
    {
        return direction == Up || direction == Down || direction == Left || direction == Right;
    }

    // Vector2Int型のセルの中心を取得
    // Vector3Int型に変換し、Map.Grid.GetCellCenterWorldメソッドを使ってセルの中心を取得
    // その結果をVector2にキャストして返す
    public static Vector2 Center2D(this Vector2Int cell)
    {
        Vector3Int threeDimensionCell = new(cell.x, cell.y, 0);
        Vector3 cellCenterWorld = Map.Grid.GetCellCenterWorld(threeDimensionCell);
        return Vector2Int.RoundToInt((Vector2)cellCenterWorld);
    }
}