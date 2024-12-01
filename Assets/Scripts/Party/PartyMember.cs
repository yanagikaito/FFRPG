using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMember
{
    public GameObject ActorPrefab { get; private set; }

    public BattleStatus Status { get; private set; }

    public PartyMember(GameObject actorPrefab, BattleStatus status)
    {
        this.ActorPrefab = actorPrefab;
        this.Status = status;
    }
}
