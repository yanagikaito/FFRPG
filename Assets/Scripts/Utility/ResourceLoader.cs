using GluonGui.WorkspaceWindow.Views.WorkspaceExplorer.Explorer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceLoader
{
    public static string enemyDataPath = "ScriptableObjects/EnemyData";
    public static string enemyPath = "ScriptableObjects/EnemyPacks";
    public static string partyMemberPath = "ScriptableObjects/PartyMembers";

    // enemy data
    public static string Ghost = enemyDataPath + "Ghost";

    // enemy packs
    public static string TwoGhost = enemyDataPath + "TwoGhost";

    // party members
    public static string Blue = partyMemberPath + "Blue";
    public static string Black = partyMemberPath + "Black";
    public static string Red = partyMemberPath + "Red";
    public static string White = partyMemberPath + "White";

    // other
    public static string BattleTransition = "BattleTransition";

    public static T Load<T>(string resource) where T : Object
    {
        T loadedItem = Resources.Load<T>(resource);

        if (loadedItem != null)
        {
            return loadedItem;
        }
        else
        {
            Debug.LogError($"Could not locate {resource}");
            return null;
        }
    }
}
