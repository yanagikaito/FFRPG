using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Map : MonoBehaviour
{

    // ���̃N���X�ɃO���b�h�ւ̎Q�Ƃ�ۑ����邾���ōς�
    // �N�����ɂ���������邱�Ƃ��ł���
    // �ÓI�v���p�e�B
    // ���̃N���X����ȒP�ɃA�N�Z�X�ł���悤�ɂ���
    public static Grid Grid { get; private set; }

    private void Awake()
    {
        Grid = FindObjectOfType<Grid>();
    }

    void Start()
    {

    }


    void Update()
    {

    }
}
