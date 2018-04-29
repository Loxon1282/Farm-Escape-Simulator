using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _DoAnimalControllera : MonoBehaviour {

    public Text touchText;
    float screenWidth;
    public float triggerValue;
    float deltaY;
    int touchNumber;
    bool isControlling = false;


    void Start () {

        screenWidth = Screen.width * 3 / 4;
        isControlling = false;

    }

	void Update () {
        
        if (Input.touches.Length > 0)
        {
            int i = 0;
            foreach (var touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began && isControlling == false)
                {
                    if (touch.position.x < screenWidth)
                    { 
                        deltaY = touch.position.y;
                        touchNumber = i;
                        isControlling = true;
                    }
                }
                else if(isControlling == true&&touchNumber==i&&touch.phase == TouchPhase.Ended)
                {
                    triggerValue = 0;
                    isControlling = false;
                }

                i++;

            }

            if(isControlling == true)
            {
                triggerValue = Mathf.Round((Input.touches[touchNumber].position.y - deltaY) * 100f) / 10000f;
            }
            if (triggerValue > 1.0f)
                triggerValue = 1.0f;
            else if (triggerValue < -1.0f)
                triggerValue = -1.0f;
            touchText.text = "TOUCHES: " + Input.touchCount + " POS: " + Input.touches[touchNumber].position + " VALUE: "+triggerValue;

        }

        else
            touchText.text = "ZERO";

    }
    
}
