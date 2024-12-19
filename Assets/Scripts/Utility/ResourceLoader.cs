using GluonGui.WorkspaceWindow.Views.WorkspaceExplorer.Explorer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceLoader
{
    private const string EnemyDataPath = "ScriptableObjects/EnemyData/";
    private const string EnemyPath = "ScriptableObjects/EnemyPacks/";
    private const string PartyMemberPath = "ScriptableObjects/PartyMembers/";
    private const string BattleTransitionPath = "BattleTransition";

    // Enemy data
    public static string Ghost => CombinePath(EnemyDataPath, "Ghost");

    // Enemy packs
    public static string TwoGhost => CombinePath(EnemyPath, "TwoGhost");

    // Party members
    public static string Blue => CombinePath(PartyMemberPath, "Blue");
    public static string Black => CombinePath(PartyMemberPath, "Black");
    public static string Red => CombinePath(PartyMemberPath, "Red");
    public static string White => CombinePath(PartyMemberPath, "White");

    // Other
    public static string BattleTransition => BattleTransitionPath;

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

    private static string CombinePath(string basePath, string fileName)
    {
        return $"{basePath}{fileName}";
    }
}