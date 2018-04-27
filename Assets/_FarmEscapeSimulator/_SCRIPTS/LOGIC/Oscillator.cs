using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {

    [SerializeField]
    RectTransform Scale;        //UI element responsible for osciilation

    [SerializeField]
    float oExtSpeed;            // oscillation speed added to base speed

    [SerializeField]
    float oMinSpeed;            // min oscillator speed

    RectTransform arrow;

    float height;

    [HideInInspector]
    public float oState;               // Oscillation state(0-1, 0.5 perfect value)
    float oDirection;           // direction of oscillation

    bool working;

    // Use this for initialization
    void Start () {

        arrow = Scale.transform.Find("arrow").GetComponent<RectTransform>();
        height = Scale.transform.GetComponent<RectTransform>().sizeDelta.y;
        height /= 2;

        oState = 0.5f;
        oDirection = 1;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OscillationLogic(float State)
    {
        float step = (oExtSpeed * State + oMinSpeed) * oDirection;

        if (oState + step >= 1)
        {
            oState = 1 - ((oState + step) - 1);
            oDirection = -1;
        }
        else if ((oState + step) <= 0)
        {
            oState = (oState + step) * -1;
            oDirection = 1;
        }
        else oState += step;

        SetArrow(oState);
    }

    public void SetArrow(float value)
    {
        arrow.localPosition = new Vector2(arrow.localPosition.x, height * (value - 0.5f) * 2);
    }

}
