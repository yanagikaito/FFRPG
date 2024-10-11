using System.Collections;
using UnityEngine;

public class CharacterMover
{
    private readonly Character character;
    private readonly Transform transform;
    private const float TimeToMoveOneSquare = 0.375f;

    // キャラクターが移動中かどうかを示すプロパティ
    public bool IsMoving { get; private set; }

    public CharacterMover(Character character)
    {
        this.character = character;
        transform = character.transform;
    }

    // 方向が基本的な方向（上、下、左、右）であり、かつキャラクターが移動中でない場合
    // 移動コルーチンを開始
    public void Move(Vector2Int direction)
    {
        if (direction.IsBasic() && !IsMoving)
        {
            character.StartCoroutine(CoMove(direction));
        }
    }

    // IsMovingをtrueに設定し、開始位置と終了位置を取得
    // whileループ内でキャラクターの位置を補間し、終了位置に到達するまで移動
    // 移動が完了したらIsMovingをfalseに設定
    private IEnumerator CoMove(Vector2Int direction)
    {
        IsMoving = true;

        Vector2 startingPosition = GetCellCenter2D(character.gameObject);
        Vector2 endingPosition = GetCellCenter2D(character.gameObject) + direction;

        float elapsedTime = 0f;

        while ((Vector2)transform.position != endingPosition)
        {
            transform.position = Vector2.Lerp(startingPosition, endingPosition, elapsedTime / TimeToMoveOneSquare);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endingPosition;
        IsMoving = false;
    }

    // オブジェクトの現在のセルの中心を取得
    private Vector2 GetCellCenter2D(GameObject gameObject)
    {
        var cellPosition = Map.Grid.GetCell2D(gameObject);
        return Map.Grid.GetCellCenter2D(cellPosition);
    }
}
