using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{

    private InputHandler InputHandler;
    protected override void Awake()
    {
        base.Awake();
        InputHandler = new InputHandler(this);
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        InputHandler.CheckInput();
    }
}
