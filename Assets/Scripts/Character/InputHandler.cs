using UnityEngine;

// InputHandler�N���X�F�v���C���[�̓��͂���������N���X
public class InputHandler
{
    private readonly PlayerController playerController;
    private Command command;

    // Command�񋓌^�F�v���C���[�̃R�}���h���`
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

    // �R���X�g���N�^�FPlayerController�I�u�W�F�N�g��������
    public InputHandler(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    // CheckInput���\�b�h�F�v���C���[�̓��͂��`�F�b�N���A�Ή�����R�}���h��ݒ�
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

    // HandleCommand���\�b�h�F�󂯎�����R�}���h������
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

    // ProcessMovement���\�b�h�F�ړ��R�}���h���������A�L�����N�^�[���ړ�
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

    // ProcessInteract���\�b�h�F�C���^���N�V�����R�}���h������
    private void ProcessInteract()
    {
        Vector2Int cellToCheck = playerController.Facing + Game.Map.Grid.GetCell2D(playerController.gameObject);

        // �L�[�����݂��邩�m�F
        if (Game.Map.OccupiedCells.TryGetValue(cellToCheck, out var interactable) && interactable is Interactable)
        {
            ((Interactable)interactable).Interact();
        }
    }

    // ProcessOpenMenu���\�b�h�F���j���[�I�[�v���R�}���h������
    private void ProcessOpenMenu()
    {
        Game.OpenMenu();
    }
}