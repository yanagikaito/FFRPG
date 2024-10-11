using System.Collections;
using UnityEngine;

public class CharacterMover
{
    private readonly Character character;
    private readonly Transform transform;
    private const float TimeToMoveOneSquare = 0.375f;

    // �L�����N�^�[���ړ������ǂ����������v���p�e�B
    public bool IsMoving { get; private set; }

    public CharacterMover(Character character)
    {
        this.character = character;
        transform = character.transform;
    }

    // ��������{�I�ȕ����i��A���A���A�E�j�ł���A���L�����N�^�[���ړ����łȂ��ꍇ
    // �ړ��R���[�`�����J�n
    public void Move(Vector2Int direction)
    {
        if (direction.IsBasic() && !IsMoving)
        {
            character.StartCoroutine(CoMove(direction));
        }
    }

    // IsMoving��true�ɐݒ肵�A�J�n�ʒu�ƏI���ʒu���擾
    // while���[�v���ŃL�����N�^�[�̈ʒu���Ԃ��A�I���ʒu�ɓ��B����܂ňړ�
    // �ړ�������������IsMoving��false�ɐݒ�
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

    // �I�u�W�F�N�g�̌��݂̃Z���̒��S���擾
    private Vector2 GetCellCenter2D(GameObject gameObject)
    {
        var cellPosition = Map.Grid.GetCell2D(gameObject);
        return Map.Grid.GetCellCenter2D(cellPosition);
    }
}
