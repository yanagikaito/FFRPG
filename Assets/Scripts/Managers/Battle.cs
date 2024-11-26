using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public static EnemyPack EnemyPack;

    private readonly List<Actor> turnOrder = new List<Actor>();
    private int turnNumber = 0;

    private void Awake()
    {
        InitializeBattle();
    }

    private void Update()
    {
        if (turnOrder.Count == 0)
        {
            Debug.LogError("Turn order is empty.");
            return;
        }

        if (turnOrder[turnNumber].IsTakingTurn)
        {
            return;
        }

        CheckForEnd();
        GoToNextTurn();
    }

    private void InitializeBattle()
    {
        SpawnPartyMembers();
        SpawnEnemies();
    }

    private void SpawnPartyMembers()
    {
        Vector2 spawnPosition = new Vector2(10, 2);
        foreach (PartyMember member in Party.ActiveMembers)
        {
            if (member.ActorPrefab == null)
            {
                Debug.LogError("ActorPrefab is null for member.");
                continue;
            }

            GameObject partyMember = Instantiate(member.ActorPrefab, spawnPosition, Quaternion.identity);
            spawnPosition.y -= 2;
            Ally ally = partyMember.GetComponent<Ally>();
            if (ally != null)
            {
                turnOrder.Add(ally);
            }
            else
            {
                Debug.LogError("Ally component is missing on party member.");
            }
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < EnemyPack.Enemies.Count; i++)
        {
            Vector2 spawnPosition = new Vector2(EnemyPack.XSpawnCoordinates[i], EnemyPack.YSpawnCoordinates[i]);

            GameObject enemy = Instantiate(EnemyPack.Enemies[i].ActorPrefab, spawnPosition, Quaternion.identity);
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
        }
    }

    private void CheckForEnd()
    {
        // End check logic should be implemented here.
    }

    private void GoToNextTurn()
    {
        turnNumber = (turnNumber + 1) % turnOrder.Count;
        Actor nextActor = turnOrder[turnNumber];
        if (nextActor != null)
        {
            nextActor.StartTurn();
        }
        else
        {
            Debug.LogError("Next actor in turn order is null.");
        }
    }
}