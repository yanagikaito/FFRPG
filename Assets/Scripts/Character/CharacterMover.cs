using System.Collections;
using UnityEngine;

public class CharacterMover
{
    private readonly Character character;
    private readonly Transform transform;
    private const float TimeToMoveOneSquare = 0.375f;

    // Characterの現在の位置を基に2次元セルの座標を取得
    private Vector2Int CurrentCell => Map.Grid.GetCell2D(character.gameObject);

    // キャラクターが移動中かどうかを示すプロパティ
    public bool IsMoving { get; private set; }

    public CharacterMover(Character character)
    {
        this.character = character;
        this.transform = character.transform;
    }

    // 方向が基本的な方向（上、下、左、右）であり、かつキャラクターが移動中でない場合、移動コルーチンを開始
    public void Move(Vector2Int direction)
    {
        if (direction.IsBasic() && !IsMoving && !Map.OccupiedCells.Contains(CurrentCell + direction))
        {
            character.StartCoroutine(CoMove(direction));
        }
    }

    // IsMovingをtrueに設定し、開始位置と終了位置を取得
    // whileループ内でキャラクターの位置を補間し、終了位置に到達するまで移動
    // 移動が完了したらIsMovingをfalseに設定
    private IEnumerator CoMove(Vector2Int direction)
    {
        // 移動中フラグを立てる
        IsMoving = true;

        // キャラクターの向きを指定された方向に変更する
        character.Turn.Turn(direction);

        // 現在のセルの中心を取得
        Vector2 startingPosition = GetCellCenter2D(character.gameObject);

        // 移動先のセルの中心を計算
        Vector2 endingPosition = GetCellCenter2D(character.gameObject) + direction;

        // 移動先のセルを占有リストに追加
        Map.OccupiedCells.Add(CurrentCell + direction);

        // 現在のセルを占有リストから削除
        Map.OccupiedCells.Remove(CurrentCell);

        // 経過時間を初期化
        float elapsedTime = 0f;

        while ((Vector2)transform.position != endingPosition)
        {
            // 線形補間で位置を更新
            transform.position = Vector2.Lerp(startingPosition, endingPosition, elapsedTime / TimeToMoveOneSquare);

            // 経過時間を更新
            elapsedTime += Time.deltaTime;

            // 次のフレームまで待機
            yield return null;
        }

        // 最終位置を設定
        transform.position = endingPosition;

        // 移動完了フラグを設定
        IsMoving = false;
    }

    // オブジェクトの現在のセルの中心を取得
    private Vector2 GetCellCenter2D(GameObject gameObject)
    {
        Vector2Int cellPosition = Map.Grid.GetCell2D(gameObject);
        return Map.Grid.GetCellCenter2D(cellPosition);
    }
}