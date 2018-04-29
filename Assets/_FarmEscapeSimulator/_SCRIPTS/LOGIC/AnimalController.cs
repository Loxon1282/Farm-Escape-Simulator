using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour {


    public GameObject animal;
    AnimalStats stats;
    ProjectileComponent projComp;
	// Use this for initialization
	void Start () {

        FocusCameraOnAnimal();
        projComp = animal.GetComponent<ProjectileComponent>();
	}

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) projComp.Rotate(1);
        if (Input.GetKey(KeyCode.S)) projComp.Rotate(-1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) projComp.ToggleGliding();
        if (stats.farts > 0)
        {
            if (Input.touchCount > 0)
            {

                foreach (Touch touch in Input.touches)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        Ray ray = Camera.main.ScreenPointToRay(touch.position);
                        RaycastHit[] hits;
                        if ((hits = Physics.RaycastAll(ray)) != null)
                        {
                            foreach (RaycastHit h in hits)
                            {
                                if (h.collider.gameObject.tag == "projectile")
                                {
                                    projComp.Fart();
                                    stats.farts--;
                                }
                            }
                        }
                    }
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] hits;
                if ((hits = Physics.RaycastAll(ray)) != null)
                {
                    foreach (RaycastHit h in hits)
                    {
                        if (h.collider.gameObject.tag == "projectile")
                        {
                            projComp.Fart();
                            stats.farts--;
                        }
                    }
                }
            }
        }
        
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
