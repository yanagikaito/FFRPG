using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Vector2Int currentCell = Map.Grid.GetCell2D(this.gameObject);
        transform.position = Map.Grid.GetCellCenterWorld((Vector3Int)currentCell);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2Int currentCell = Map.Grid.GetCell2D(this.gameObject);

            // Vector3Int��Vector2Int�͈قȂ�^�ł���A���ډ��Z���邱�Ƃ͂ł��Ȃ�
            transform.position = Map.Grid.GetCellCenterWorld((Vector3Int)(currentCell + Direction.Left));
        }
        //// �Z���̒��S���x�N�g��3�Ƃ��ĕԂ�
        //Grid.GetCellCenterWorld();

        //// �x�N�g��3�̈ʒu���擾��,�O���b�h��̃Z�����x�N�g���Ƃ��ĕԂ�
        //Grid.WorldToCell();
    }
}
