using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// StationaryNPC�N���X�FCharacter�N���X���p�����AInteractable�C���^�[�t�F�[�X������
public class StationaryNPC : Character, Interactable
{
    // interaction�t�B�[���h��SerializeField�����Ō��J
    [SerializeField] private Interaction interaction;

    // interaction�v���p�e�B�Finteraction�t�B�[���h�����J
    public Interaction Interaction => interaction;

    // Interact���\�b�h�FInteraction��StartInteraction���\�b�h���Ăяo��
    public void Interact()
    {
        Interaction.StartInteraction();
    }
}