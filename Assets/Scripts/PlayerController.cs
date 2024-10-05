using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{

    void Start()
    {
        Vector2Int currentCell = Map.Grid.GetCell2D(this.gameObject);
        transform.position = Map.Grid.GetCellCenterWorld((Vector3Int)currentCell);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move.Move(Direction.Left);
        }
    }
}
