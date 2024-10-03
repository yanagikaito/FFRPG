using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �ړ��Ɏg���ꍇ�̓O���b�h�ւ̎Q�Ƃ��K�v
    // �O���b�h�v���p�e�B
    public Grid Grid { get; set; }

    // �ړ����Ă���Ƃ��ɐݒ肷��
    // �O���b�h���g�p�������ꍇ�͕K���O���b�h�ւ̎Q�Ƃ��擾����K�v������
    private void Awake()
    {
        Grid = FindObjectOfType<Grid>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector2Int currentCell = Grid.GetCell2D(this.gameObject);
        transform.position = Grid.GetCellCenterWorld((Vector3Int)currentCell);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2Int currentCell = Grid.GetCell2D(this.gameObject);

            // Vector3Int��Vector2Int�͈قȂ�^�ł���A���ډ��Z���邱�Ƃ͂ł��Ȃ�
            transform.position = Grid.GetCellCenterWorld((Vector3Int)(currentCell + Direction.Left));
        }
        //// �Z���̒��S���x�N�g��3�Ƃ��ĕԂ�
        //Grid.GetCellCenterWorld();

        //// �x�N�g��3�̈ʒu���擾��,�O���b�h��̃Z�����x�N�g���Ƃ��ĕԂ�
        //Grid.WorldToCell();
    }
}
