using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    protected Vector2 startingPosition;
    protected Vector2 battlePosition = new Vector2(0.5f, 0);
    public bool IsTakingTurn { get; protected set; } = false;

    public BattleStatus Status { get; set; }

    protected virtual void Start()
    {
        startingPosition = transform.position;
    }

    public abstract void StartTurn();
}
