using System.Collections.Generic;
using UnityEngine;

public static class Party
{
    private static readonly List<PartyMember> activeMembers = new List<PartyMember>();
    private static readonly List<PartyMember> reserveMembers = new List<PartyMember>();
    public static IReadOnlyList<PartyMember> ActiveMembers => activeMembers;

    static Party()
    {
        AddInitialMembers();
    }

    private static void AddInitialMembers()
    {
        AddMemberToActive("PartyBattlerPrefabs/PartyMember1", new BattleStatus(10, 10, 3, 2, 3));
        AddMemberToActive("PartyBattlerPrefabs/PartyMember1", new BattleStatus(10, 10, 3, 2, 3));
        AddMemberToActive("PartyBattlerPrefabs/PartyMember1", new BattleStatus(10, 10, 3, 2, 3));
    }

    private static void AddMemberToActive(string resourcePath, BattleStatus status)
    {
        GameObject prefab = Resources.Load<GameObject>(resourcePath);
        PartyMember member = new PartyMember(prefab, status);
        activeMembers.Add(member);
    }

    public static void AddActiveMember(PartyMember memberToAdd)
    {
        if (!activeMembers.Contains(memberToAdd))
        {
            activeMembers.Add(memberToAdd);
            reserveMembers.Remove(memberToAdd);
        }
    }

    public static void RemoveActiveMember(PartyMember memberToRemove)
    {
        if (activeMembers.Contains(memberToRemove))
        {
            activeMembers.Remove(memberToRemove);
            reserveMembers.Add(memberToRemove);
        }
    }
}