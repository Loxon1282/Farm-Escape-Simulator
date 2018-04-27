using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{


    [SerializeField]
    GameObject spoon;
    
    [SerializeField]
    LauncherStats stats;

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


    void Start()
    {
        lowerBound = 345;
        upperBound = 300;
        launchingBound = 270;
        aState = 0;
        SetAngles(upperBound,lowerBound);
        controled = true;
        working = true;
        SetProjectal();
    }

    void FixedUpdate()
    {
        if (working)
        {
            spoon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Lerp(aFrom, aTo, aState)));
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
        aState = Mathf.Abs((spoon.transform.rotation.eulerAngles.z - lowerBound) / (launchingBound - lowerBound));
        SetAngles(spoon.transform.rotation.eulerAngles.z, launchingBound);
    }

    void Launch()
    {
        working = false;
        stats.projectal.transform.parent = null;
        stats.projectal.GetComponent<Rigidbody>().isKinematic = false;
        stats.projectal.GetComponent<Rigidbody>().AddForce(launchVector * stats.lPower * lState);
    }

    public void SetProjectal()
    {
        Instantiate(stats.projectal, spoon.transform.position, Quaternion.identity);
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
        stats = GameManager.CurrLauncher;
    }
}