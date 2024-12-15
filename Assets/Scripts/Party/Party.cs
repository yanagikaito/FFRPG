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
        AddMemberToActive("PartyBattlerPrefabs/PartyMember1", new BattleStatus(1, 10, 10, 3, 2, 3));
    }

    private static void AddMemberToActive(string resourcePath, BattleStatus status)
    {
        GameObject blueStatus = Resources.Load<GameObject>(resourcePath);
        PartyMember blue = new PartyMember("Blue", null, "Fighter", blueStatus, status);
        activeMembers.Add(blue);
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