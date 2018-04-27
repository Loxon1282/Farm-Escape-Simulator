using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcLauncherController : MonoBehaviour {


    //Space to strech


    [SerializeField]
    float speed;

    float state;

    float direction;

    Launcher launcher;
    Oscillator oscillator;    //oscillator graphical representation and logic

    // Use this for initialization
    void Start () {

        launcher = GetComponent<Launcher>();
        oscillator = GetComponent<Oscillator>();
        direction = 0;
        state = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space")) direction = 1;
        if (Input.GetKeyUp("space"))
        {
            direction = -1;
            launcher.SetLaunch(oscillator.oState);
        }
        if (direction == -1 && state == 0) direction = 0;
    }


    // Update is called once per frame
    void FixedUpdate () {

        if (direction !=0)
        {
            StateLogic();
        }

	}

    void StateLogic()
    {
        float step = speed * direction;

        if (state + step >= 1)
        {
            state = 1;
        }
        else if ((state + step) <= 0)
        {
            state = 0;
        }
        else state += step;

        oscillator.OscillationLogic(state);
        launcher.SetState(state);
    }

}
