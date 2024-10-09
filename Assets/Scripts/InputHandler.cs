using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
    private PlayerController playerController;
    public InputHandler(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void CheckInput()
    {
        // プレイヤーが移動している間は入力が処理されないようにする
        if (playerController.IsMoving)
            return;

        KeyCode keyPressed = KeyCode.Escape;

        // キーを取得
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            keyPressed = KeyCode.LeftArrow;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            keyPressed = KeyCode.RightArrow;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            keyPressed = KeyCode.UpArrow;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            keyPressed = KeyCode.DownArrow;
        }

        if (keyPressed != KeyCode.Escape)
        {
            HandleInput(keyPressed);
        }
    }

    private void HandleInput(KeyCode keyPressed)
    {
        switch (keyPressed)
        {
            case (KeyCode.LeftArrow):
            case (KeyCode.RightArrow):
            case (KeyCode.UpArrow):
            case (KeyCode.DownArrow):
                ProcessMovementInput(keyPressed);
                break;
        }
    }

    private void ProcessMovementInput(KeyCode keyPressed)
    {
        Vector2Int direction = new Vector2Int(0, 0);

        switch (keyPressed)
        {
            case (KeyCode.LeftArrow):
                direction = Direction.Left;
                break;
            case (KeyCode.RightArrow):
                direction = Direction.Right;
                break;
            case (KeyCode.UpArrow):
                direction = Direction.Up;
                break;
            case (KeyCode.DownArrow):
                direction = Direction.Down;
                break;
        }

        playerController.Move.Move(direction);
    }
}
