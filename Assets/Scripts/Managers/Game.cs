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
            Battle.EnemyPack = Resources.Load<EnemyPack>("ScriptableObjects/EnemyPacks/TestEnemyPack");
            StartBattle();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            EndBattle();
        }
    }

    private void StartBattle()
    {
        State = GameState.Battle;
        SceneLoader.LoadBattleScene();
    }

    private void EndBattle()
    {
        SceneLoader.ReloadSavedSceneAfterBattle();
        State = GameState.World;
    }
}
