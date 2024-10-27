using System.Collections;
using UnityEngine;

public class CharacterMover
{
    private readonly Character character;
    private readonly Transform transform;
    private const float TimeToMoveOneSquare = 0.375f;

    // Characterの現在の位置を基に2次元セルの座標を取得
    private Vector2Int CurrentCell => Game.Map.Grid.GetCell2D(character.gameObject);

    // キャラクターが移動中かどうかを示すプロパティ
    public bool IsMoving { get; private set; } = false;

    public CharacterMover(Character character)
    {
        this.character = character;
        this.transform = character.transform;
    }

    // 方向が基本的な方向（上、下、左、右）であり、かつキャラクターが移動中でない場合、移動コルーチンを開始
    public void TryMove(Vector2Int direction)
    {
        if (IsMoving || !direction.IsBasic()) return;

        // キャラクターの向きを指定された方向に変更する
        character.Turn.Turn(direction);
        Vector2Int targetCell = CurrentCell + direction;

        if (CanMoveIntoCell(targetCell, direction))
        {
            // 移動先のセルを占有リストに追加
            Game.Map.OccupiedCells.Add(CurrentCell + direction, character);

            // 現在のセルを占有リストから削除
            Game.Map.OccupiedCells.Remove(CurrentCell);

            character.StartCoroutine(CoMove(direction));
        }
    }

    private bool CanMoveIntoCell(Vector2Int targetCell, Vector2Int direction)
    {
        if (IsCellOccupied(targetCell))
        {
            return false;
        }
        Ray2D ray = new Ray2D(CurrentCell.Center2D(), direction);
        RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 2.0f);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.distance < Game.Map.Grid.cellSize.x)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsCellOccupied(Vector2Int cell)
    {
        return Game.Map.OccupiedCells.ContainsKey(cell);
    }

    // IsMovingをtrueに設定し、開始位置と終了位置を取得
    // whileループ内でキャラクターの位置を補間し、終了位置に到達するまで移動
    // 移動が完了したらIsMovingをfalseに設定
    private IEnumerator CoMove(Vector2Int direction)
    {
        // 移動中フラグを立てる
        IsMoving = true;

        // 現在のセルの中心を取得
        Vector2 startingPosition = GetCellCenter2D(character.gameObject);

        // 移動先のセルの中心を計算
        Vector2 endingPosition = GetCellCenter2D(character.gameObject) + direction;

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
        Vector2Int cellPosition = Game.Map.Grid.GetCell2D(gameObject);
        return Game.Map.Grid.GetCellCenter2D(cellPosition);
    }
}