using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // ��L����Ă���Z���̃��X�g��ێ�����ÓI�v���p�e�B
    public Dictionary<Vector2Int, MonoBehaviour> OccupiedCells { get; private set; } = new Dictionary<Vector2Int, MonoBehaviour>();

    // ���̃N���X�ɃO���b�h�ւ̎Q�Ƃ�ۑ����邾���ōς�
    // �N�����ɂ���������邱�Ƃ��ł���
    // ���̃N���X����ȒP�ɃA�N�Z�X�ł���悤�ɂ���
    public Grid Grid { get; private set; }

    // Awake���\�b�h�̓I�u�W�F�N�g�̏��������ɌĂяo�����
    private void Awake()
    {
        // �V�[������Grid�R���|�[�l���g�������āAGrid�v���p�e�B�ɐݒ肷��
        Grid = GetComponent<Grid>();

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

