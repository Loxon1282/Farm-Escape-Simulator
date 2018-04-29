using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Prefs", order = 1)]
public class LauncherStats : ScriptableObject
{ 

    [SerializeField]
    public GameObject projectile;       // animal
    [SerializeField]
    public float speed;                // arm speed
    [SerializeField]
    public float lPower;               // launch power an angle  
    public float perfAngle = 45.0f;
    [SerializeField]
    public float deviationAngle;
    [SerializeField]
    public float maxSpins;             // how many spins do you need to get full value
    [SerializeField]
    public float launchTime;           // time limit after which launcher will launch

    public LauncherStats()
    {
    }

    }
