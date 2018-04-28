using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour {

    public Swipe swipeController;
	
	
	void Update () {

        if (swipeController.SwipeLeft)
        {
            Debug.Log("swipe left");
        }
        if (swipeController.Tap)
        {
            Debug.Log("tap");
        }
        if (swipeController.SwipeUp)
            Debug.Log("up");
    }
    
}
