using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public static EnemyPack EnemyPack;

    private List<Actor> TurnOrder = new List<Actor>();
    private int turnNumber = 0;

    private void Start()
    {
        SpawnPartyMembers();
        SpawnEnemies();
    }

    private void Update()
    {
        if (TurnOrder[turnNumber].IsTakingTurn)
            return;

        else
        {
            CheckForEnd();
            GoToNextTurn();
        }
    }

    private void SpawnPartyMembers()
    {
        Vector2 spawnPosition = new Vector2(10, 2);
        foreach (PartyMember member in Party.ActiveMembers)
        {
            GameObject partyMember = Instantiate(member.ActorPrefab, spawnPosition, Quaternion.identity);
            spawnPosition.y -= 2;
            TurnOrder.Add(partyMember.GetComponent<Ally>());
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < EnemyPack.Enemies.Count; i++)
        {
            Vector2 spawnPosition = new Vector2(EnemyPack.XSpawnCoordinates[i], EnemyPack.YSpawnCoordinates[i]);
            GameObject enemy = Instantiate(EnemyPack.Enemies[i].ActorPrefab, spawnPosition, Quaternion.identity);
            TurnOrder.Add(enemy.GetComponent<Enemy>());
        }
    }

    private void CheckForEnd()
    {

    }

    private void GoToNextTurn()
    {
        turnNumber = (turnNumber + 1) % TurnOrder.Count;
        TurnOrder[turnNumber].StartTurn();
    }
}
