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
    void Update()
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
                            if (h.collider.gameObject.tag == "projectile") animal.GetComponent<ProjectileComponent>().AnimalInteraction();
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
                        animal.GetComponent<ProjectileComponent>().AnimalInteraction();
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
