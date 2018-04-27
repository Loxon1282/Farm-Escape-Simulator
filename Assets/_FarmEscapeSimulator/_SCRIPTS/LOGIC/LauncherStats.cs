using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherStats{

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
