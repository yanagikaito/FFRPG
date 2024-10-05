using UnityEngine;

public static class Direction
{
    // 4�̕��������ꂼ��Q�Ƃ���B
    // Up�̓x�N�g��2��01
    public static readonly Vector2Int Up = new(0, 1);
    public static readonly Vector2Int Down = new(0, -1);
    public static readonly Vector2Int Left = new(-1, 0);
    public static readonly Vector2Int Right = new(1, 0);

    // �g�����\�b�h
    public static bool IsBasic(this Vector2Int direction)
    {
        if (direction == Direction.Up ||
            direction == Direction.Down ||
            direction == Direction.Left ||
            direction == Direction.Right)
        {
            return true;
        }
        return false;
    }
}
