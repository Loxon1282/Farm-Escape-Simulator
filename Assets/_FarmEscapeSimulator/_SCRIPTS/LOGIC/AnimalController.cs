using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour {


    public GameObject animal;
    AnimalStats stats;
	// Use this for initialization
	void Start () {

        FocusCameraOnAnimal();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void SetAnimal(GameObject obj)
    {
        animal = obj;
    }

    public void SetStats()
    {
        stats = animal.GetComponent<ProjectileComponent>().stats;
    }

    void FocusCameraOnAnimal()
    {
        Camera.main.GetComponent<PrimitiveCameraFollow>().target = animal.transform;
    }
}
