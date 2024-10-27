using System.Collections;
using UnityEngine;

public class CharacterMover
{
    private readonly Character character;
    private readonly Transform transform;
    private const float TimeToMoveOneSquare = 0.375f;
    public bool IsMoving { get; private set; } = false;

    public CharacterMover(Character character)
    {
        this.character = character;
        this.transform = character.transform;
    }

    public void TryMove(Vector2Int direction)
    {
        if (IsMoving || !direction.IsBasic()) return;
        character.Turn.Turn(direction);
        Vector2Int targetCell = character.CurrentCell + direction;
        if (CanMoveIntoCell(targetCell, direction))
        {
            // 移動先のセルを占有リストに追加
            Map.OccupiedCells.Add(targetCell, character);
            // 現在のセルを占有リストから削除
            Map.OccupiedCells.Remove(character.CurrentCell);
            character.StartCoroutine(CoMove(direction));
        }
    }

    private bool CanMoveIntoCell(Vector2Int targetCell, Vector2Int direction)
    {
        if (IsCellOccupied(targetCell))
        {
            return false;
        }

        // レイキャストをターゲットセルの方向にのみ行う
        Vector2 rayOrigin = GetCellCenter2D(character.gameObject);
        Vector2 rayDirection = ((Vector2)direction).normalized; // Vector2に変換してから正規化
        float rayDistance = Map.Grid.cellSize.x / 2f; // セルサイズの半分の距離を設定

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance, ~LayerMask.GetMask("Player"));
        Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.red, 2.0f);

        if (hit.collider != null && hit.collider.CompareTag("Collisions"))
        {
            Debug.Log($"Hit detected: {hit.collider.name} at distance {hit.distance}");
            return false;
        }

        return true;
    }

    private bool IsCellOccupied(Vector2Int cell)
    {
        return Map.OccupiedCells.ContainsKey(cell);
    }

    private IEnumerator CoMove(Vector2Int direction)
    {
        if (!CanMoveIntoCell(character.CurrentCell + direction, direction))
        {
            yield break; // 衝突が検出されたら移動をキャンセル
        }

        IsMoving = true;
        Vector2 startingPosition = GetCellCenter2D(character.gameObject);
        Vector2 endingPosition = startingPosition + (Vector2)direction;
        float elapsedTime = 0f;

        while (elapsedTime < TimeToMoveOneSquare)
        {
            transform.position = Vector2.Lerp(startingPosition, endingPosition, elapsedTime / TimeToMoveOneSquare);
            elapsedTime += Time.deltaTime;

            // 移動中に衝突を再確認
            if (!CanMoveIntoCell(character.CurrentCell + direction, direction))
            {
                transform.position = startingPosition; // 元の位置に戻す
                IsMoving = false;
                yield break;
            }

            // 次のフレームまで待機
            yield return null;
        }

        transform.position = endingPosition;
        IsMoving = false;
    }

    private Vector2 GetCellCenter2D(Vector2Int cell)
    {
        return Map.Grid.GetCellCenter2D(cell);
    }

    private Vector2 GetCellCenter2D(GameObject gameObject)
    {
        Vector2Int cellPosition = Map.Grid.GetCell2D(gameObject);
        return GetCellCenter2D(cellPosition);
    }
}