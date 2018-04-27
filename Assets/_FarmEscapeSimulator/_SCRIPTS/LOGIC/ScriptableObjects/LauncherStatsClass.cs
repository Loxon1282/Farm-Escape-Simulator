using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Prefs", order = 1)]
public class LauncherStatsClass : ScriptableObject
{
    public string objectName = "New LauncherStats";
    public bool colorIsRandom = false;
    public Color thisColor = Color.white;
}