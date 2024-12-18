using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    World,
    Cutscene,
    Battle,
    Menu,
}

public class Game : MonoBehaviour
{
    public static GameState State { get; private set; }

    public static Map Map { get; private set; }

    public static PlayerController PlayerController { get; private set; }

    public static void OpenMenu() => State = GameState.Menu;

    public static void CloseMenu() => State = GameState.World;

    [SerializeField] private Map startingMap;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector2Int startingCell;

    private void Awake()
    {
        if (Map == null)
        {
            Map = Instantiate(startingMap);
        }

        if (PlayerController == null)
        {
            GameObject gameObject = Instantiate(playerPrefab, startingCell.Center2D(), Quaternion.identity);
            PlayerController = gameObject.GetComponent<PlayerController>();
        }
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(PlayerController);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Battle.EnemyPack = ResourceLoader.Load<EnemyPack>(ResourceLoader.TwoGhost);
            StartCoroutine(Co_StartBattle());
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            EndBattle();
        }
    }

    private IEnumerator Co_StartBattle()
    {
        State = GameState.Battle;
        Instantiate(ResourceLoader.Load<GameObject>(ResourceLoader.BattleTransition),
            PlayerController.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        SceneLoader.LoadBattleScene();
    }

    private void EndBattle()
    {
        SceneLoader.ReloadSavedSceneAfterBattle();
        State = GameState.World;
    }
}
