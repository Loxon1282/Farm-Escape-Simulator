using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Prefs", order = 1)]
public class LauncherStats : ScriptableObject
{ 

    [SerializeField]
    public GameObject projectal;       // animal
    [SerializeField]
    public float speed;                // rotation speed
    [SerializeField]
    public float lPower;               // launch power an angle  
    [SerializeField]
    public float perfAngle;
    [SerializeField]
    public float deviationAngle;
    [SerializeField]
    public float maxSpins;             // how many spins do you need to get full value
    [SerializeField]
    public float lounchTime;           // time limit after which launcher will launch

}
