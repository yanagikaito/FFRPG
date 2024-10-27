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
            // �ړ���̃Z�����L���X�g�ɒǉ�
            Map.OccupiedCells.Add(targetCell, character);
            // ���݂̃Z�����L���X�g����폜
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

        // ���C�L���X�g���^�[�Q�b�g�Z���̕����ɂ̂ݍs��
        Vector2 rayOrigin = GetCellCenter2D(character.gameObject);
        Vector2 rayDirection = ((Vector2)direction).normalized; // Vector2�ɕϊ����Ă��琳�K��
        float rayDistance = Map.Grid.cellSize.x / 2f; // �Z���T�C�Y�̔����̋�����ݒ�

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
            yield break; // �Փ˂����o���ꂽ��ړ����L�����Z��
        }

        IsMoving = true;
        Vector2 startingPosition = GetCellCenter2D(character.gameObject);
        Vector2 endingPosition = startingPosition + (Vector2)direction;
        float elapsedTime = 0f;

        while (elapsedTime < TimeToMoveOneSquare)
        {
            transform.position = Vector2.Lerp(startingPosition, endingPosition, elapsedTime / TimeToMoveOneSquare);
            elapsedTime += Time.deltaTime;

            // �ړ����ɏՓ˂��Ċm�F
            if (!CanMoveIntoCell(character.CurrentCell + direction, direction))
            {
                transform.position = startingPosition; // ���̈ʒu�ɖ߂�
                IsMoving = false;
                yield break;
            }

            // ���̃t���[���܂őҋ@
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