using UnityEngine;

// InputHandlerクラス：プレイヤーの入力を処理するクラス
public class InputHandler
{
    private readonly PlayerController playerController;
    private Command command;

    // Command列挙型：プレイヤーのコマンドを定義
    private enum Command
    {
        None,
        MoveLeft,
        MoveRight,
        MoveUp,
        MoveDown,
        Interact,
    }

    // コンストラクタ：PlayerControllerオブジェクトを初期化
    public InputHandler(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    // CheckInputメソッド：プレイヤーの入力をチェックし、対応するコマンドを設定
    public void CheckInput()
    {
        command = Command.None;

        if (Input.GetKey(KeyCode.A)) command = Command.MoveLeft;
        else if (Input.GetKey(KeyCode.D)) command = Command.MoveRight;
        else if (Input.GetKey(KeyCode.W)) command = Command.MoveUp;
        else if (Input.GetKey(KeyCode.S)) command = Command.MoveDown;
        else if (Input.GetKeyDown(KeyCode.Space)) command = Command.Interact;

        if (command != Command.None) HandleCommand(command);
    }

    // HandleCommandメソッド：受け取ったコマンドを処理
    private void HandleCommand(Command command)
    {
        if (IsMovementCommand(command))
        {
            ProcessMovement(command);
        }
        else if (command == Command.Interact)
        {
            ProcessInteract();
        }
    }

    // IsMovementCommandメソッド：コマンドが移動コマンドかどうかを判定
    private bool IsMovementCommand(Command command)
    {
        return command == Command.MoveLeft ||
               command == Command.MoveRight ||
               command == Command.MoveUp ||
               command == Command.MoveDown;
    }

    // ProcessMovementメソッド：移動コマンドを処理し、キャラクターを移動
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

    // ProcessInteractメソッド：インタラクションコマンドを処理
    private void ProcessInteract()
    {
        Vector2Int cellToCheck = playerController.Facing + Map.Grid.GetCell2D(playerController.gameObject);

        // キーが存在するか確認
        if (Map.OccupiedCells.ContainsKey(cellToCheck))
        {
            // セルが占有されている場合にのみ実行
            if (Map.OccupiedCells[cellToCheck] is Interactable interactable)
            {
                interactable.Interact();
            }
        }
    }
}