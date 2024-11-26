using System.Collections;
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
        AddMemberToActive("PartyBattlerPrefabs/PartyMember1");
        AddMemberToActive("PartyBattlerPrefabs/PartyMember1");
        AddMemberToActive("PartyBattlerPrefabs/PartyMember1");
    }

    private static void AddMemberToActive(string resourcePath)
    {
        PartyMember member = new PartyMember(Resources.Load<GameObject>(resourcePath));
        activeMembers.Add(member);
    }

    public static void AddActiveMember(PartyMember memberToAdd)
    {
        if (activeMembers.Contains(memberToAdd))
            return;

        activeMembers.Add(memberToAdd);
        reserveMembers.Remove(memberToAdd);
    }

    public static void RemoveActiveMember(PartyMember memberToRemove)
    {
        if (!activeMembers.Contains(memberToRemove))
            return;

        activeMembers.Remove(memberToRemove);
        reserveMembers.Add(memberToRemove);
    }
}