using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryNPC : Character
{
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move.Move(Direction.Left);
        }
    }
}
