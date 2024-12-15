using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyMember
{
    public string Name { get; private set; }
    public GameObject ActorPrefab { get; private set; }

    public BattleStatus Status { get; private set; }

    public Image Portrait { get; private set; }

    public string Job { get; private set; } = "Some job";

    public PartyMember(string name, Image portrait, string job, GameObject actorPrefab, BattleStatus status)
    {
        this.Name = name;
        this.Portrait = portrait;
        this.Job = job;
        this.ActorPrefab = actorPrefab;
        this.Status = status;
    }
}
