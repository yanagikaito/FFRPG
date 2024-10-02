using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GridExtensions
{
    // �x�N�g����int�ɕԂ�
    public static Vector2Int GetCell2D(this Grid grid, GameObject gameObject)
    {
        // �ϊ��ʒu
        Vector3Int position = gameObject.transform.position;

        // �x�N�g��2�ɃL���X�g
        return (Vectoro2Int)grid.WorldToCell(position);
    }

    public static Vector2Int GetCenter2Int(this Grid grid, Vector2Int cell)
    {
        // 3�����쐬
        Vector3Int threeDimensionCell = new Vector3Int(cell.x, cell.y, 0);

        // ���S�̂��߂Ƀx�N�g��2�ɃL���X�g
        return (Vector2)grid.GetCellCenterWorld(threeDimensionCell);
    }
}