using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public CharacterMover Move { get; private set; }

    // ���`���v���p�e�B
    // IsMoving �v���p�e�B�̒l��Ԃ�
    public bool IsMoving => Move.IsMoving;

    protected virtual void Awake()
    {
        Move = new CharacterMover(this);
    }

    protected virtual void Start()
    {
        Vector2Int currentCell = Map.Grid.GetCell2D(this.gameObject);
        transform.position = Map.Grid.GetCellCenterWorld((Vector3Int)currentCell);
    }

    protected virtual void Update()
    {

    }
}
