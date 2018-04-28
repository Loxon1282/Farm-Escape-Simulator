using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour {

    public AnimalStats stats;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "baloon":
                print(other.tag);
                break;
            case "bird":
                print(other.tag);
                break;
            case "coin":
                print(other.tag);
                break;
            case "feedBag":
                print(other.tag);
                break;
            case "flyingMine":
                print(other.tag);
                break;
            case "gears":
                print(other.tag);
                break;
            case "mine":
                print(other.tag);
                break;
            case "plank":
                print(other.tag);
                break;
            case "screw":
                print(other.tag);
                break;
            case "specialFeedBag":
                print(other.tag);
                break;
        }
    }

    public void AnimalInteraction()
    {
        gameObject.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
    }

}
