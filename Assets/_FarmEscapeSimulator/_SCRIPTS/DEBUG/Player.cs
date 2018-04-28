using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody rb;
    public float force=100.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start () {
		
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(new Vector3(0, 1,1)*force);
        }
        if(rb.velocity.magnitude > 100.0f)
        rb.velocity = rb.velocity.normalized * 100.0f;

    }
}
