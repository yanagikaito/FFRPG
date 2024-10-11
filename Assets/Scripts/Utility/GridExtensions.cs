using UnityEngine;

public static class GridExtensions
{
    // GameObject�̈ʒu���O���b�h��̃Z���ɕϊ�
    // gameObject�̈ʒu��Vector3Int�ɕϊ�
    // ���̈ʒu���O���b�h�̃Z���ʒu�ɕϊ����AVector2Int�Ƃ��ĕԂ�
    public static Vector2Int GetCell2D(this Grid grid, GameObject gameObject)
    {
        Vector3Int position = Vector3Int.FloorToInt(gameObject.transform.position);
        return (Vector2Int)grid.WorldToCell(position);
    }

    // 2D�Z���̒��S�ʒu�����߂�
    // Vector2Int�Z����Vector3Int�ɕϊ�
    // �O���b�h�̒��S�ʒu��Vector3�Ŏ擾���A�����Vector2Int�Ƃ��ĕԂ�
    public static Vector2Int GetCenter2Int(this Grid grid, Vector2Int cell)
    {
        Vector3Int threeDimensionCell = new(cell.x, cell.y, 0);
        Vector3 cellCenterWorld = grid.GetCellCenterWorld(threeDimensionCell);
        return Vector2Int.RoundToInt((Vector2)cellCenterWorld);
    }

    // �Z���̒��S�ʒu��2D�x�N�g���Ƃ��Ď擾
    // cellPosition�̒��S���v�Z���AVector2�Ƃ��ĕԂ�
    // �e���W��0.5�����Z���邱�ƂŁA�Z���̒��S���擾
    public static Vector2 GetCellCenter2D(this Grid grid, Vector2Int cellPosition)
    {
        return new Vector2(cellPosition.x + 0.5f, cellPosition.y + 0.5f);
    }
}