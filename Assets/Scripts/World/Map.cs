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

    // ��L����Ă���Z���̃��X�g��ێ�����ÓI�v���p�e�B
    public static Dictionary<Vector2Int, MonoBehaviour> OccupiedCells { get; private set; } = new Dictionary<Vector2Int, MonoBehaviour>();

    // Awake���\�b�h�̓I�u�W�F�N�g�̏��������ɌĂяo�����
    private void Awake()
    {
        // �V�[������Grid�R���|�[�l���g�������āAGrid�v���p�e�B�ɐݒ肷��
        Grid = FindObjectOfType<Grid>();

        // OccupiedCells���X�g���N���A����
        OccupiedCells.Clear();
    }

    void Start()
    {

    }

    void Update()
    {

    }
}

