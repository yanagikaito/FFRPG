using UnityEngine;

public static class GridExtensions
{
    // ベクトルをintに返す
    public static Vector2Int GetCell2D(this Grid grid, GameObject gameObject)
    {
        // 変換位置
        Vector3Int position = Vector3Int.FloorToInt(gameObject.transform.position);

        // ベクトル2にキャスト
        return (Vector2Int)grid.WorldToCell(position);
    }

    public static Vector2Int GetCenter2Int(this Grid grid, Vector2Int cell)
    {
        // 3次元作成
        Vector3Int threeDimensionCell = new Vector3Int(cell.x, cell.y, 0);

        // 安全のためにベクトル2にキャスト
        Vector3 cellCenterWorld = grid.GetCellCenterWorld(threeDimensionCell);
        return Vector2Int.RoundToInt((Vector2)cellCenterWorld);
    }
}