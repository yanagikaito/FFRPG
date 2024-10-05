using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public CharacterMover Move { get; private set; }

    private void Awake()
    {
        Move = new CharacterMover(this);
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
