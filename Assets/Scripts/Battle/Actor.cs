using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    protected Vector2 startingPosition;
    protected Vector2 battlePosition = new Vector2(0, 0);
    public bool IsTakingTurn { get; protected set; } = false;

    protected virtual void Start()
    {
        startingPosition = transform.position;
    }

    public abstract void StartTurn();
}
