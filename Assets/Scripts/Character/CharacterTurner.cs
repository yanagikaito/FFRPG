using UnityEngine;

public class CharacterTurner
{
    public Vector2Int Facing { get; private set; } = Direction.Down;

    public void Turn(Vector2Int direction)
    {
        if (IsBasic(direction))
        {
            Facing = direction;
        }
    }

    public void TurnAround() => Facing = new Vector2Int(-Facing.x, -Facing.y);

    private bool IsBasic(Vector2Int direction)
    {
        // 基本的な方向が上、下、左、右であることを確認
        return direction == Vector2Int.up || direction == Vector2Int.down ||
               direction == Vector2Int.left || direction == Vector2Int.right;
    }
}
