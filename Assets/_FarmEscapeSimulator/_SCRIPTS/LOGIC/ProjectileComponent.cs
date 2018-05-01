using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour {


    [SerializeField]
    float FartPower;
    [SerializeField]
    float TorqueForce=10;
    [SerializeField]
    float GlidingForce = 10;
    [SerializeField]
    float VelocityModifie = 10;
    [SerializeField]
    float Nosedive = 10;
    public AnimalStats stats;

    public bool isGliding;

    Rigidbody rb;
	// Use this for initialization
	void Start () {
       rb = GetComponent<Rigidbody>();
       isGliding = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isGliding)
        {
            Gliding();
        }
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

    public void Fart()
    {
        rb.AddForce(gameObject.transform.right * FartPower, ForceMode.Impulse);
    }

    public void Rotate(float x)
    {
        Vector3 Force = gameObject.transform.forward * x * TorqueForce;
        rb.AddTorque(Force, ForceMode.Acceleration);
    }

    void Gliding()
    {
        float dot = Vector3.Dot(gameObject.transform.up, rb.velocity.normalized) * -1;
        Vector3 Force = gameObject.transform.up * dot * GlidingForce * rb.velocity.magnitude * VelocityModifie;
        Vector3 ForceT = gameObject.transform.forward * dot * Nosedive * -1;
        rb.AddTorque(ForceT, ForceMode.Acceleration);
        rb.AddForce(Force, ForceMode.Acceleration);
    }

    public void GlidingMode(bool x = true)
    {
        isGliding = x;
    }

    public void ToggleGliding()
    {
        isGliding = !isGliding;
    }
}
