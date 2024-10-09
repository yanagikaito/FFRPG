using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover
{
    public Character character;
    private const float TIME_TO_MOVE_ONE_SQUARE = .375f;
    private Transform transform;

    // プロパティの移動
    public bool IsMoving { get; private set; }

    // コンストラクタ
    public CharacterMover(Character character)
    {
        this.character = character;
        this.transform = character.transform;
    }

    public void Move(Vector2Int direction)
    {
        if (direction.IsBasic() || IsMoving == false)
        {
            character.StartCoroutine(Co_Move(direction));
        }
    }

    public IEnumerator Co_Move(Vector2Int direction)
    {
        IsMoving = true;

        // 現在いるセルを取得
        Vector2Int startingCell = Map.Grid.GetCell2D(character.gameObject);

        // 最後のセル
        Vector2Int endingCell = startingCell + direction;

        // 開始位置を取得
        // 開始セルでセルの中心2dを取得
        Vector2 startingPosition = Map.Grid.GetCellCenter2D(startingCell);

        // 終了位置を取得
        Vector2 endingPosition = Map.Grid.GetCellCenter2D(endingCell);

        float elapsedTime = 0;

        // whileループに入れる
        while ((Vector2)transform.position != endingPosition)
        {
            // 2つのポイントの間をワープする
            character.transform.position = Vector2.Lerp((Vector2)startingPosition,
                (Vector2)endingPosition, elapsedTime / TIME_TO_MOVE_ONE_SQUARE);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endingPosition;
        IsMoving = false;
    }
}
