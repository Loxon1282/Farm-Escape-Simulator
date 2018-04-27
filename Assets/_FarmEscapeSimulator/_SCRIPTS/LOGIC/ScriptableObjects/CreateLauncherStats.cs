using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateLauncherStats
{
    [MenuItem("Assets/Create/Launcher Stats")]
    public static void CreateMyAsset()
    {
        LauncherStats asset = ScriptableObject.CreateInstance<LauncherStats>();

        AssetDatabase.CreateAsset(asset, "Assets/NewLauncherStats.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}