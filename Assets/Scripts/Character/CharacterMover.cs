using System.Collections;
using UnityEngine;

public class CharacterMover
{
    private readonly Character character;
    private readonly Transform transform;
    private const float TimeToMoveOneSquare = 0.375f;

    // Character�̌��݂̈ʒu�����2�����Z���̍��W���擾
    private Vector2Int CurrentCell => Map.Grid.GetCell2D(character.gameObject);

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
        if (IsMoving) return;

        // �L�����N�^�[�̌������w�肳�ꂽ�����ɕύX����
        character.Turn.Turn(direction);
        Vector2Int targetCell = CurrentCell + direction;

        if (direction.IsBasic() && IsCellEmpty(targetCell))
        {
            character.StartCoroutine(CoMove(direction));
        }
    }

    private bool IsCellEmpty(Vector2Int cell)
    {
        return !(Map.OccupiedCells.ContainsKey(cell));
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

        // �ړ���̃Z�����L���X�g�ɒǉ�
        Map.OccupiedCells.Add(CurrentCell + direction, character);

        // ���݂̃Z�����L���X�g����폜
        Map.OccupiedCells.Remove(CurrentCell);

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
        Vector2Int cellPosition = Map.Grid.GetCell2D(gameObject);
        return Map.Grid.GetCellCenter2D(cellPosition);
    }
}