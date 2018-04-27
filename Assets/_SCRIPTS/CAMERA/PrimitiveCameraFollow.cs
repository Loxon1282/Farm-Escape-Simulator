using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveCameraFollow : MonoBehaviour {

	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void Start(){
		Application.targetFrameRate = 60;
	}
	void FixedUpdate () {

		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		transform.LookAt (target.position);
        
		
		
	}
}
