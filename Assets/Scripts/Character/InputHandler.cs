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
    }

    // �R���X�g���N�^�FPlayerController�I�u�W�F�N�g��������
    public InputHandler(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    // CheckInput���\�b�h�F�v���C���[�̓��͂��`�F�b�N���A�Ή�����R�}���h��ݒ�
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

    // HandleCommand���\�b�h�F�󂯎�����R�}���h������
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

    // IsMovementCommand���\�b�h�F�R�}���h���ړ��R�}���h���ǂ����𔻒�
    private bool IsMovementCommand(Command command)
    {
        return command == Command.MoveLeft ||
               command == Command.MoveRight ||
               command == Command.MoveUp ||
               command == Command.MoveDown;
    }

    // ProcessMovement���\�b�h�F�ړ��R�}���h���������A�L�����N�^�[���ړ�
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

    // ProcessInteract���\�b�h�F�C���^���N�V�����R�}���h������
    private void ProcessInteract()
    {
        Vector2Int cellToCheck = playerController.Facing + Map.Grid.GetCell2D(playerController.gameObject);

        // �L�[�����݂��邩�m�F
        if (Map.OccupiedCells.ContainsKey(cellToCheck))
        {
            // �Z������L����Ă���ꍇ�ɂ̂ݎ��s
            if (Map.OccupiedCells[cellToCheck] is Interactable interactable)
            {
                interactable.Interact();
            }
        }
    }
}