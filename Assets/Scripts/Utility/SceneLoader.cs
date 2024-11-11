using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SceneLoader�N���X�̓V�[���̃��[�h���s���ÓI�N���X
public static class SceneLoader
{
    // �f�o�b�O�V�[���̃r���h�C���f�b�N�X
    //private static int debugSceneBuildIndex = 0;

    // �o�g���V�[���̃r���h�C���f�b�N�X
    private static int battleSceneBuildIndex = 1;

    // �Z�[�u���ꂽ�V�[���̃r���h�C���f�b�N�X
    private static int savedSceneBuildIndex;

    // �Z�[�u���ꂽ�v���C���[�̈ʒu
    private static Vector2 savedPlayerLocation;

    // �o�g���V�[�������[�h���郁�\�b�h
    public static void LoadBattleScene()
    {
        // ���݂̃V�[���̃r���h�C���f�b�N�X��ۑ�
        savedSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        // �v���C���[�̌��݂̈ʒu��ۑ�
        savedPlayerLocation = Game.PlayerController.CurrentCell.Center2D();

        // �v���C���[�̃Q�[���I�u�W�F�N�g���A�N�e�B�u��
        Game.PlayerController.gameObject.SetActive(false);

        // �o�g���V�[�������[�h
        SceneManager.LoadScene(battleSceneBuildIndex);
    }

    // �o�g����ɃZ�[�u���ꂽ�V�[���������[�h���郁�\�b�h
    public static void ReloadSavedSceneAfterBattle()
    {
        // �V�[�������[�h���ꂽ��Ƀv���C���[�̈ʒu�ƃQ�[���I�u�W�F�N�g�𕜌����郁�\�b�h��o�^
        SceneManager.sceneLoaded += RestorePlayerPositionAndGameObject;

        // �Z�[�u���ꂽ�V�[�������[�h
        SceneManager.LoadScene(savedSceneBuildIndex);
    }

    // �v���C���[�̈ʒu�ƃQ�[���I�u�W�F�N�g�𕜌����郁�\�b�h
    public static void RestorePlayerPositionAndGameObject(Scene scene, LoadSceneMode mode)
    {
        // �v���C���[�̈ʒu�𕜌�
        Game.PlayerController.transform.position = savedPlayerLocation;

        // �v���C���[�̃Q�[���I�u�W�F�N�g���A�N�e�B�u��
        Game.PlayerController.gameObject.SetActive(true);

        // �V�[�����[�h��̃C�x���g���炱�̃��\�b�h������
        SceneManager.sceneLoaded -= RestorePlayerPositionAndGameObject;
    }
}