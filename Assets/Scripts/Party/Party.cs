using System.Collections.Generic;
using UnityEngine;

public static class Party
{
    private static readonly List<PartyMember> activeMembers = new List<PartyMember>();
    private static readonly List<PartyMember> reserveMembers = new List<PartyMember>();
    public static IReadOnlyList<PartyMember> ActiveMembers => activeMembers;

    static Party()
    {
        PartyMember Blue = ResourceLoader.Load<PartyMember>(ResourceLoader.Blue);
        PartyMember Black = ResourceLoader.Load<PartyMember>(ResourceLoader.Black);
        PartyMember Red = ResourceLoader.Load<PartyMember>(ResourceLoader.Red);
        PartyMember White = ResourceLoader.Load<PartyMember>(ResourceLoader.White);

        AddActiveMember(Blue);
        AddActiveMember(Black);
        AddActiveMember(Red);
        AddActiveMember(White);
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