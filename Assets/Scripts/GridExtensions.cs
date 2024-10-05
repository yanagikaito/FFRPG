using UnityEngine;

public static class GridExtensions
{
    // �x�N�g����int�ɕԂ�
    public static Vector2Int GetCell2D(this Grid grid, GameObject gameObject)
    {
        // �ϊ��ʒu
        Vector3Int position = Vector3Int.FloorToInt(gameObject.transform.position);

        // �x�N�g��2�ɃL���X�g
        return (Vector2Int)grid.WorldToCell(position);
    }

    public static Vector2Int GetCenter2Int(this Grid grid, Vector2Int cell)
    {
        // 3�����쐬
        Vector3Int threeDimensionCell = new Vector3Int(cell.x, cell.y, 0);

        // ���S�̂��߂Ƀx�N�g��2�ɃL���X�g
        Vector3 cellCenterWorld = grid.GetCellCenterWorld(threeDimensionCell);
        return Vector2Int.RoundToInt((Vector2)cellCenterWorld);
    }

    public static Vector2 GetCellCenter2D(this Grid grid, Vector2Int cellPosition)
    {
        // �Z���̒��S���v�Z���郍�W�b�N�������ɋL�q
        return new Vector2(cellPosition.x + 0.5f, cellPosition.y + 0.5f);
    }
}