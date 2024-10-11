using UnityEngine;

public static class GridExtensions
{
    // GameObjectの位置をグリッド上のセルに変換
    // gameObjectの位置をVector3Intに変換
    // その位置をグリッドのセル位置に変換し、Vector2Intとして返す
    public static Vector2Int GetCell2D(this Grid grid, GameObject gameObject)
    {
        Vector3Int position = Vector3Int.FloorToInt(gameObject.transform.position);
        return (Vector2Int)grid.WorldToCell(position);
    }

    // 2Dセルの中心位置を求める
    // Vector2IntセルをVector3Intに変換
    // グリッドの中心位置をVector3で取得し、それをVector2Intとして返す
    public static Vector2Int GetCenter2Int(this Grid grid, Vector2Int cell)
    {
        Vector3Int threeDimensionCell = new(cell.x, cell.y, 0);
        Vector3 cellCenterWorld = grid.GetCellCenterWorld(threeDimensionCell);
        return Vector2Int.RoundToInt((Vector2)cellCenterWorld);
    }

    // セルの中心位置を2Dベクトルとして取得
    // cellPositionの中心を計算し、Vector2として返す
    // 各座標に0.5を加算することで、セルの中心を取得
    public static Vector2 GetCellCenter2D(this Grid grid, Vector2Int cellPosition)
    {
        return new Vector2(cellPosition.x + 0.5f, cellPosition.y + 0.5f);
    }
}