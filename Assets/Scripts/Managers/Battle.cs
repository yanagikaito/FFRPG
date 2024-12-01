using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public static EnemyPack EnemyPack;

    private readonly List<Actor> turnOrder = new List<Actor>();
    private int turnNumber;
    private bool setupComplete;

    public IReadOnlyList<Actor> TurnOrder => turnOrder;

    private void Awake()
    {
        InitializeBattle();
    }

    private void Update()
    {
        if (!setupComplete)
        {
            DetermineTurnOrderAndStartFirstTurn();
            return;
        }

        if (turnOrder.Count == 0)
        {
            Debug.LogError("Turn order is empty.");
            return;
        }

        if (turnOrder[turnNumber].IsTakingTurn) return;

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
            if (!ValidateActorPrefab(member.ActorPrefab, "party member")) continue;

            GameObject partyMember = Instantiate(member.ActorPrefab, spawnPosition, Quaternion.identity);
            if (AddToTurnOrder<Ally>(partyMember, member.Status)) spawnPosition.y -= 2;
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < EnemyPack.Enemies.Count; i++)
        {
            Vector2 spawnPosition = new Vector2(EnemyPack.XSpawnCoordinates[i], EnemyPack.YSpawnCoordinates[i]);
            if (!ValidateActorPrefab(EnemyPack.Enemies[i].ActorPrefab, "enemy")) continue;

            GameObject enemyActor = Instantiate(EnemyPack.Enemies[i].ActorPrefab, spawnPosition, Quaternion.identity);
            AddToTurnOrder<Enemy>(enemyActor, EnemyPack.Enemies[i].Status);
        }
    }

    private void DetermineTurnOrderAndStartFirstTurn()
    {
        turnOrder.Sort((a, b) => b.Status.Initiative.CompareTo(a.Status.Initiative));
        if (turnOrder.Count > 0)
        {
            turnOrder[0].StartTurn();
        }
        setupComplete = true;
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

    private bool ValidateActorPrefab(GameObject prefab, string actorType)
    {
        if (prefab == null)
        {
            Debug.LogError($"ActorPrefab is null for {actorType}.");
            return false;
        }
        return true;
    }

    private bool AddToTurnOrder<T>(GameObject actorObject, BattleStatus status) where T : Actor
    {
        T actor = actorObject.GetComponent<T>();
        if (actor == null)
        {
            Debug.LogError($"{typeof(T).Name} component is missing on actor: {actorObject.name}");
            return false;
        }
        actor.Status = status;
        turnOrder.Add(actor);
        return true;
    }
}