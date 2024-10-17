using UnityEngine;

public class InputHandler
{
    private readonly PlayerController playerController;

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
        if (Input.GetKey(KeyCode.LeftArrow)) command = Command.MoveLeft;
        else if (Input.GetKey(KeyCode.RightArrow)) command = Command.MoveRight;
        else if (Input.GetKey(KeyCode.UpArrow)) command = Command.MoveUp;
        else if (Input.GetKey(KeyCode.DownArrow)) command = Command.MoveDown;

        if (command != Command.None) HandleCommand(command);
    }

    private void HandleCommand(Command command)
    {
        if (IsMovementCommand(command))
        {
            ProcessMovement(command);
        }
    }

    private bool IsMovementCommand(Command command)
    {
        return command == Command.MoveLeft || command == Command.MoveRight ||
               command == Command.MoveUp || command == Command.MoveDown;
    }

    private void ProcessMovement(Command command)
    {
        Vector2Int direction = command switch
        {
            Command.MoveLeft => Direction.Left,
            Command.MoveRight => Direction.Right,
            Command.MoveUp => Direction.Up,
            Command.MoveDown => Direction.Down,
            _ => Vector2Int.zero
        };

        playerController.Move.TryMove(direction);
    }
}