using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public CharacterMover Move { get; private set; }

    protected virtual void Awake()
    {
        Move = new CharacterMover(this);
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }
}
