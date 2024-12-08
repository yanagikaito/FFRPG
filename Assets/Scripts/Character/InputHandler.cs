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
        OpenMenu,
    }

    // コンストラクタ：PlayerControllerオブジェクトを初期化
    public InputHandler(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    // CheckInputメソッド：プレイヤーの入力をチェックし、対応するコマンドを設定
    public void CheckInput()
    {
        if (Game.State != GameState.World)
            return;

        command = Command.None;

        if (Input.GetKey(KeyCode.A)) command = Command.MoveLeft;
        else if (Input.GetKey(KeyCode.D)) command = Command.MoveRight;
        else if (Input.GetKey(KeyCode.W)) command = Command.MoveUp;
        else if (Input.GetKey(KeyCode.S)) command = Command.MoveDown;
        else if (Input.GetKeyDown(KeyCode.Space)) command = Command.Interact;
        else if (Input.GetKeyDown(KeyCode.Escape)) command = Command.OpenMenu;

        if (command != Command.None) HandleCommand();
    }

    // HandleCommandメソッド：受け取ったコマンドを処理
    private void HandleCommand()
    {
        switch (command)
        {
            case Command.MoveLeft:
            case Command.MoveRight:
            case Command.MoveUp:
            case Command.MoveDown:
                ProcessMovement();
                break;
            case Command.Interact:
                ProcessInteract();
                break;
            case Command.OpenMenu:
                ProcessOpenMenu();
                break;
        }
    }

    // ProcessMovementメソッド：移動コマンドを処理し、キャラクターを移動
    private void ProcessMovement()
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
        Vector2Int cellToCheck = playerController.Facing + Game.Map.Grid.GetCell2D(playerController.gameObject);

        // キーが存在するか確認
        if (Game.Map.OccupiedCells.TryGetValue(cellToCheck, out var interactable) && interactable is Interactable)
        {
            ((Interactable)interactable).Interact();
        }
    }

    // ProcessOpenMenuメソッド：メニューオープンコマンドを処理
    private void ProcessOpenMenu()
    {
        Game.OpenMenu();
    }
}