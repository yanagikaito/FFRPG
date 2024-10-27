using System.Collections;
using UnityEngine;

public class CharacterMover
{
    private readonly Character character;
    private readonly Transform transform;
    private const float TimeToMoveOneSquare = 0.375f;

    // Character�̌��݂̈ʒu�����2�����Z���̍��W���擾
    private Vector2Int CurrentCell => Game.Map.Grid.GetCell2D(character.gameObject);

    // �L�����N�^�[���ړ������ǂ����������v���p�e�B
    public bool IsMoving { get; private set; } = false;

    public CharacterMover(Character character)
    {
        this.character = character;
        this.transform = character.transform;
    }

    // ��������{�I�ȕ����i��A���A���A�E�j�ł���A���L�����N�^�[���ړ����łȂ��ꍇ�A�ړ��R���[�`�����J�n
    public void TryMove(Vector2Int direction)
    {
        if (IsMoving || !direction.IsBasic()) return;

        // �L�����N�^�[�̌������w�肳�ꂽ�����ɕύX����
        character.Turn.Turn(direction);
        Vector2Int targetCell = CurrentCell + direction;

        if (CanMoveIntoCell(targetCell, direction))
        {
            // �ړ���̃Z�����L���X�g�ɒǉ�
            Game.Map.OccupiedCells.Add(CurrentCell + direction, character);

            // ���݂̃Z�����L���X�g����폜
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

    // IsMoving��true�ɐݒ肵�A�J�n�ʒu�ƏI���ʒu���擾
    // while���[�v���ŃL�����N�^�[�̈ʒu���Ԃ��A�I���ʒu�ɓ��B����܂ňړ�
    // �ړ�������������IsMoving��false�ɐݒ�
    private IEnumerator CoMove(Vector2Int direction)
    {
        // �ړ����t���O�𗧂Ă�
        IsMoving = true;

        // ���݂̃Z���̒��S���擾
        Vector2 startingPosition = GetCellCenter2D(character.gameObject);

        // �ړ���̃Z���̒��S���v�Z
        Vector2 endingPosition = GetCellCenter2D(character.gameObject) + direction;

        // �o�ߎ��Ԃ�������
        float elapsedTime = 0f;

        while ((Vector2)transform.position != endingPosition)
        {
            // ���`��Ԃňʒu���X�V
            transform.position = Vector2.Lerp(startingPosition, endingPosition, elapsedTime / TimeToMoveOneSquare);

            // �o�ߎ��Ԃ��X�V
            elapsedTime += Time.deltaTime;

            // ���̃t���[���܂őҋ@
            yield return null;
        }

        // �ŏI�ʒu��ݒ�
        transform.position = endingPosition;

        // �ړ������t���O��ݒ�
        IsMoving = false;
    }

    // �I�u�W�F�N�g�̌��݂̃Z���̒��S���擾
    private Vector2 GetCellCenter2D(GameObject gameObject)
    {
        Vector2Int cellPosition = Game.Map.Grid.GetCell2D(gameObject);
        return Game.Map.Grid.GetCellCenter2D(cellPosition);
    }
}