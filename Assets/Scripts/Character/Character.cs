using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public abstract class Character : MonoBehaviour
{
    public CharacterMover Move { get; private set; }

    public CharacterTurner Turn { get; private set; }

    public CharacterAnimator Animator { get; private set; }

    // ���`���v���p�e�B
    // IsMoving �v���p�e�B�̒l��Ԃ�
    public bool IsMoving => Move.IsMoving;

    public Vector2Int Facing => Turn.Facing;

    protected virtual void Awake()
    {
        Move = new CharacterMover(this);
        Turn = new CharacterTurner();
        Animator = new CharacterAnimator(this);
    }

    protected virtual void Start()
    {
        Vector2Int currentCell = Map.Grid.GetCell2D(this.gameObject);
        transform.position = Map.Grid.GetCellCenterWorld((Vector3Int)currentCell);
        Map.OccupiedCells.Add(currentCell, this);
    }

    protected virtual void Update()
    {
        Animator.ChooseLayer();
        Animator.UpdateParameters();
    }
}
