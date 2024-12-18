using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Party Member", menuName = "New Party Member")]
public class PartyMember : ScriptableObject
{
    [SerializeField] private string moniker;
    [SerializeField] private GameObject actorPrefab;
    [SerializeField] private BattleStatus status;
    [SerializeField] private Sprite portrait;
    [SerializeField] private string job = "Some job";

    public string Name => moniker;
    public GameObject ActorPrefab => actorPrefab;
    public BattleStatus Status => status;
    public Sprite Portrait => portrait;
    public string Job => job;
}
