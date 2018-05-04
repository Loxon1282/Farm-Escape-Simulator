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
    [SerializeField]
    float MinePower = 10;
    [SerializeField]
    float BallonTime = 3;
    [SerializeField]
    float BallonForce = 10;
    [SerializeField]
    float SlowFactor = 0.2f;

    public bool isGliding;
    bool isFloating;

    AnimalController contr;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        isGliding = false;
        isFloating = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isGliding)
        {
            Gliding();
        }
        if (isFloating)
        {
            Floating();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "baloon":
                StartCoroutine("StartFloat");
                break;
            case "bird":
                SlowDown();
                break;
            case "coin":
                print(other.tag);
                break;
            case "feedBag":
                print(other.tag);
                break;
            case "scrap":
                contr.AddScrap();
                break;
            case "mine":
                rb.AddForce(new Vector3(Mathf.Cos(Mathf.Deg2Rad * 45), Mathf.Sin(Mathf.Deg2Rad * 45), 0) * MinePower, ForceMode.VelocityChange);
                contr.Damage();
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

    public void ConnectControler(AnimalController x)
    {
        contr = x;
    }

    IEnumerator StartFloat()
    {
        isFloating = true;
        yield return new WaitForSeconds(BallonTime);
        isFloating = false;
    }

    void Floating()
    {
        rb.AddForce(Vector3.up * BallonForce, ForceMode.Acceleration);
    }

    void SlowDown()
    {
        rb.AddForce(rb.velocity * -1 * SlowFactor, ForceMode.VelocityChange);
    }
}
