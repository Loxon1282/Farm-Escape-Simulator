﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{

    [SerializeField]
    GameObject arm;
    [SerializeField]
    GameObject spoon;
    
    [SerializeField]
    LauncherStats stats;
    [SerializeField]
    bool preLoadedStats = false;

    float aFrom;
    float aTo;
    float aState;

    float upperBound;           // 270, -90 in editor = after launch
    float lowerBound;           // 345, -15 in editor = ready to launch
    float launchingBound;       // around 280/290

    Vector3 launchVector;
    float lAngle;
    float lState;

    bool controled;             // is launcher controlled by controller
    bool working;

    GameObject localProjectile;


    void Start()
    {
        lowerBound = -30;
        upperBound = 15;
        launchingBound = 30;
        aState = 0;
        SetAngles(upperBound,lowerBound);
        controled = true;
        working = true;
        if (!preLoadedStats) LoadStats();
        SetProjectile();
    }

    void FixedUpdate()
    {
        if (working)
        {
            arm.transform.localRotation = Quaternion.Euler(new Vector3(Mathf.Lerp(aFrom, aTo, aState),0,0));
            if (!controled)
            {
                StateLogic();
                if (aState == 1) Launch();
            }
        }
    }

    void StateLogic()
    {
        if ((aState + stats.speed) < 1)
        {
            aState += stats.speed;
        }
        else
        {
            aState = 1;
        }
    }

    public void SetState(float value)
    {
        if(controled)aState = value;
    }

    public void SetAngles(float from, float to)
    {
        aFrom = from;
        aTo = to;
    }

    public void SetLaunch(float angle = 0.5f) // perfect value for angle - 0.5
    {
        lAngle = (stats.perfAngle - stats.deviationAngle) + angle * stats.deviationAngle * 2;
        launchVector = new Vector3(Mathf.Cos(Mathf.Deg2Rad * lAngle), Mathf.Sin(Mathf.Deg2Rad * lAngle), 0);
        launchVector = launchVector.normalized;
        lState = aState;
        controled = false;
        aState = Mathf.Abs((arm.transform.rotation.eulerAngles.z - lowerBound) / (launchingBound - lowerBound));
        SetAngles(arm.transform.rotation.eulerAngles.z, launchingBound);
    }

    void Launch()
    {
        working = false;
        localProjectile.transform.parent = null;
        localProjectile.GetComponent<Rigidbody>().isKinematic = false;
        localProjectile.GetComponent<Rigidbody>().AddForce(launchVector * stats.lPower * lState);
    }

    public void SetProjectile()
    {
        localProjectile = Instantiate(stats.projectile, spoon.transform.position, Quaternion.identity);
        localProjectile.transform.parent = spoon.transform;
        localProjectile.GetComponent<Rigidbody>().isKinematic = true;
    }


    public float getMaxSpins()
    {
        return stats.maxSpins;
    }

    public float getLaunchTime()
    {
        return stats.lounchTime;
    }

   public void LoadStats()
    {
        stats = GameManager.Instance.currLauncher;
    }
}