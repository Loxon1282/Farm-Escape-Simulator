using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraController : MonoBehaviour
{

    public PrimitiveCameraFollow CameraScript;
    public Transform target;
    Transform targetMark;
    public GameObject[] MenuBackgroundsPoints;
    public GameObject[] MenuElements;

    private void Awake()
    {
        GetCameraScript();
    }

    private void FixedUpdate()
    {
        if (targetMark.position != target.position)
        {
            target.position = Vector3.Slerp(target.position, targetMark.position, 4.0f * Time.deltaTime);
        }

    }

    public void SetSceneView(int i)
    {
        targetMark = MenuBackgroundsPoints[i].transform;
        for (int x = 0; x < MenuElements.Length; x++)
        {
            if (x == i)
                MenuElements[x].SetActive(true);
            else
                MenuElements[x].SetActive(false);
        }

    }
    private void GetCameraScript()
    {
        CameraScript = Camera.main.GetComponent<PrimitiveCameraFollow>();
        CameraScript.target = target;
        targetMark = MenuBackgroundsPoints[0].transform;
    }

}
