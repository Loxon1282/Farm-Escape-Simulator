using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDropdown : MonoBehaviour {


	// Use this for initialization
	void Start () {
        foreach(string n in GameManager.Instance.GetProjectileNames())
        {
            print(n);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
