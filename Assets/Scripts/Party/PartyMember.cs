using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMember
{
    public GameObject ActorPrefab { get; private set; }

    public PartyMember(GameObject actorPrefab)
    {
        this.ActorPrefab = actorPrefab;
    }
}
