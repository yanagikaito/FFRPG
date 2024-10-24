using System.Collections;
using UnityEngine;

public class CharacterMover
{
    private readonly Character character;
    private readonly Transform transform;
    private const float TimeToMoveOneSquare = 0.375f;
    private Vector2Int CurrentCell => Map.Grid.GetCell2D(character.gameObject);
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
        Vector2Int targetCell = CurrentCell + direction;
        if (CanMoveIntoCell(targetCell, direction))
        {
            character.StartCoroutine(CoMove(direction));
        }
    }

    private bool CanMoveIntoCell(Vector2Int targetCell, Vector2Int direction)
    {
        if (IsCellOccupied(targetCell))
        {
            return false;
        }

        Vector2 rayOrigin = GetCellCenter2D(character.gameObject) + (Vector2)direction * 0.1f;
        Vector2 rayDirection = ((Vector2)direction).normalized;
        float rayDistance = Map.Grid.cellSize.x / 2f;

        RaycastHit2D[] hits = Physics2D.RaycastAll(rayOrigin, rayDirection, rayDistance, ~LayerMask.GetMask("Player"));
        Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.red, 0.5f);

        foreach (RaycastHit2D hit in hits)
        {
            Debug.Log($"Hit detected: {hit.collider.name} at distance {hit.distance}");
            if (hit.collider != null && hit.distance < rayDistance && hit.collider.CompareTag("Collisions"))
            {
                return false;
            }
        }
        return true;
    }

    private bool IsCellOccupied(Vector2Int cell)
    {
        return Map.OccupiedCells.ContainsKey(cell);
    }

    private IEnumerator CoMove(Vector2Int direction)
    {
        if (!CanMoveIntoCell(CurrentCell + direction, direction))
        {
            yield break; // 衝突が検出されたら移動をキャンセル
        }

        IsMoving = true;
        Vector2 startingPosition = GetCellCenter2D(character.gameObject);
        Vector2 endingPosition = GetCellCenter2D(character.gameObject) + (Vector2)direction;
        float elapsedTime = 0f;

        while (elapsedTime < TimeToMoveOneSquare)
        {
            transform.position = Vector2.Lerp(startingPosition, endingPosition, elapsedTime / TimeToMoveOneSquare);
            elapsedTime += Time.deltaTime;

            // 移動中に衝突を再確認
            if (!CanMoveIntoCell(CurrentCell + direction, direction))
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

    private Vector2 GetCellCenter2D(GameObject gameObject)
    {
        Vector2Int cellPosition = Map.Grid.GetCell2D(gameObject);
        return Map.Grid.GetCellCenter2D(cellPosition);
    }
}