using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour {

    public Swipe swipeController;
	void Start () {
		
	}
	
	
	void Update () {
        if (swipeController.SwipeLeft)
        {
            Debug.Log("SWIPE LEFT");
        }
        if (swipeController.Tap)
        {
            Debug.Log("TAP");
        }
        if (swipeController.SwipeUp)
            Debug.Log("UP");
	}
}
