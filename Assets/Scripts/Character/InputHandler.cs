using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
    private PlayerController playerController;

    private Command command;

    private enum Command
    {
        None,
        MoveLeft,
        MoveRight,
        MoveUp,
        MoveDown,
    }
    public InputHandler(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void CheckInput()
    {
        command = Command.None;

        // ÉLÅ[ÇéÊìæ
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            command = Command.MoveLeft;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            command = Command.MoveRight;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            command = Command.MoveUp;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            command = Command.MoveDown;
        }

        if (command != Command.None)
        {
            HandleCommand(command);
        }
    }

    private void HandleCommand(Command command)
    {
        switch (command)
        {
            case (Command.MoveLeft):
            case (Command.MoveRight):
            case (Command.MoveUp):
            case (Command.MoveDown):
                ProcessMovement(command);
                break;
        }
    }

    private void ProcessMovement(Command command)
    {
        Vector2Int direction = new Vector2Int(0, 0);

        switch (command)
        {
            case (Command.MoveLeft):
                direction = Direction.Left;
                break;
            case (Command.MoveRight):
                direction = Direction.Right;
                break;
            case (Command.MoveUp):
                direction = Direction.Up;
                break;
            case (Command.MoveDown):
                direction = Direction.Down;
                break;
        }

        playerController.Move.Move(direction);
    }
}
