using UnityEngine;

public static class Direction
{
    public static readonly Vector2Int Up = new(0, 1);
    public static readonly Vector2Int Down = new(0, -1);
    public static readonly Vector2Int Left = new(-1, 0);
    public static readonly Vector2Int Right = new(1, 0);

    // Vector2Int�^�̕�����Up�ADown�ALeft�ARight�̂����ꂩ�ł��邩���m�F
    // ��{�I�ȕ����ł����true��Ԃ��A����ȊO�Ȃ�false��Ԃ�
    public static bool IsBasic(this Vector2Int direction)
    {
        return direction == Up || direction == Down || direction == Left || direction == Right;
    }

    // Vector2Int�^�̃Z���̒��S���擾
    // Vector3Int�^�ɕϊ����AMap.Grid.GetCellCenterWorld���\�b�h���g���ăZ���̒��S���擾
    // ���̌��ʂ�Vector2�ɃL���X�g���ĕԂ�
    public static Vector2 Center2D(this Vector2Int cell)
    {
        Vector3Int threeDimensionCell = new(cell.x, cell.y, 0);
        Vector3 cellCenterWorld = Map.Grid.GetCellCenterWorld(threeDimensionCell);
        return Vector2Int.RoundToInt((Vector2)cellCenterWorld);
    }
}