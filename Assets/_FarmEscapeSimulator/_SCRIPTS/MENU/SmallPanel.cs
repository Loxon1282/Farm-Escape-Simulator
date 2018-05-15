using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPanel : MonoBehaviour {


    [SerializeField]
    GameObject Panel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TogglePanel()
    {
        if (Panel != null)
        {
            if (Panel.activeInHierarchy) DisablePanel();
            else EnablePanel();
        }
        else Debug.LogError("No Panel assigned");
    }

    public void EnablePanel()
    {
        if (Panel != null) Panel.SetActive(true);
        else Debug.LogError("No Panel assigned");
    }

    public void DisablePanel()
    {
        if (Panel != null) Panel.SetActive(false);
        else Debug.LogError("No Panel assigned");
    }

}
