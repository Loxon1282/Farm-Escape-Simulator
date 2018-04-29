using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _DoAnimalControllera : MonoBehaviour {

    public Text touchText;
    bool isButtonDown = false;


	void Start () {
        
	}
	// Update is called once per frame
	void Update () {

        if (Input.touches.Length > 0&&!isButtonDown)
        {
            touchText.text = "TOUCHES: " + Input.touchCount+" POS: "+Input.touches[0].position;
            
        }
        else
            touchText.text = "ZERO";

    }
    public void ButtonClicked()
    {
        isButtonDown = true;
    }
    public void ButtonUnClicked()
    {
        isButtonDown = false;
    }
    
}
