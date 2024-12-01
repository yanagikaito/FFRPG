using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "New Enemy Data")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private GameObject actorPrefab;
    [SerializeField] private BattleStatus status;

    public GameObject ActorPrefab => actorPrefab;
    public BattleStatus Status => status;
}
