using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover
{
    public Character character;
    private const float TIME_TO_MOVE_ONE_SQUARE = .375f;
    private Transform transform;

    // �v���p�e�B�̈ړ�
    public bool IsMoving { get; private set; }

    // �R���X�g���N�^
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

        // ���݂���Z�����擾
        Vector2Int startingCell = Map.Grid.GetCell2D(character.gameObject);

        // �Ō�̃Z��
        Vector2Int endingCell = startingCell + direction;

        // �J�n�ʒu���擾
        // �J�n�Z���ŃZ���̒��S2d���擾
        Vector2 startingPosition = Map.Grid.GetCellCenter2D(startingCell);

        // �I���ʒu���擾
        Vector2 endingPosition = Map.Grid.GetCellCenter2D(endingCell);

        float elapsedTime = 0;

        // while���[�v�ɓ����
        while ((Vector2)transform.position != endingPosition)
        {
            // 2�̃|�C���g�̊Ԃ����[�v����
            character.transform.position = Vector2.Lerp((Vector2)startingPosition,
                (Vector2)endingPosition, elapsedTime / TIME_TO_MOVE_ONE_SQUARE);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endingPosition;
        IsMoving = false;
    }
}
