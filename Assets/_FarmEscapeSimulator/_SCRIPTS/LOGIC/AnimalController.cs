using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class AnimalController : MonoBehaviour
{

    [HideInInspector]
    public GameObject animal;
    public AnimalStats stats;
    ProjectileComponent projComp;

    [SerializeField]
    GameObject glider;

    [SerializeField]        //UI
    GameObject button;
    [SerializeField]
    GameObject fartBar;
    [SerializeField]
    GameObject group;

    GameObject IGroup;
    GameObject IFartBar;

    public PlayerPrefs PlayerPrefs;

    float screenMargin;
    public float triggerValue;
    float deltaY;
    int touchNumber;
    bool isControlling = false;

    // Use this for initialization
    void Start()
    {

        FocusCameraOnAnimal();
        screenMargin = Screen.width * 1/4;
        isControlling = false;
        ShowUI();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) projComp.Rotate(1);
        if (Input.GetKey(KeyCode.S)) projComp.Rotate(-1);
        if (Input.GetKey(KeyCode.Q)) HideUI();
        if (triggerValue!=0)projComp.Rotate(triggerValue);
    }

    // Update is called once per frame
    void Update()
    {
        IFartBar.GetComponent<Slider>().value = stats.farts;

        if (Input.GetKeyDown(KeyCode.G))
        {
            TurnOnGlider();
        }

        if (Input.touchCount > 0)
        {
            int i = 0;
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    if (stats.farts > 0)
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
                    if (!isControlling)
                    {
                        if (touch.position.x < (Screen.width - screenMargin) && touch.position.x > screenMargin)
                        {
                            deltaY = touch.position.y;
                            touchNumber = i;
                            isControlling = true;
                        }
                    }
                }
                else if (isControlling && touchNumber == i && touch.phase == TouchPhase.Ended)
                {
                    triggerValue = 0;
                    isControlling = false;
                }
                i++;
                if (isControlling == true)
                {
                    triggerValue = Mathf.Round((Input.touches[touchNumber].position.y - deltaY) * 100f) / 10000f;
                }
            }
            if (triggerValue > 1.0f)
                triggerValue = 1.0f;
            else if (triggerValue < -1.0f)
                triggerValue = -1.0f;
        }

        if (stats.farts > 0)
        {
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

    public void Damage()
    {

    }

    public void TurnOnGlider()
    {
        if (projComp.isGliding) HideGlider();
        else ShowGlider();
        projComp.ToggleGliding();
    }

    public void SetAnimal(GameObject obj)
    {
        animal = obj;
        projComp = animal.GetComponent<ProjectileComponent>();
        SetControler();
    }

    public void SetControler()
    {
        projComp.ConnectControler(gameObject.GetComponent<AnimalController>());
    }

    void FocusCameraOnAnimal()
    {
        Camera.main.GetComponent<PrimitiveCameraFollow>().target = animal.transform;
    }

    void ShowGlider()
    {
        //animal.transform.rotation = Quaternion.Euler(new Vector3(animal.transform.rotation.eulerAngles.x, animal.transform.rotation.eulerAngles.y, Quaternion.LookRotation(animal.GetComponent<Rigidbody>().velocity.normalized).z));
        GameObject glid = Instantiate(glider, animal.transform.position, animal.transform.rotation);
        glid.transform.SetParent(animal.transform);
    }

    void HideGlider()
    {
        Destroy(animal.transform.Find("glider(Clone)").gameObject);
    }

    public void AddScrap()
    {

    }

    void ShowGlideButton(RectTransform parent)
    { 
        GameObject b = Instantiate(button, parent);
        //b.GetComponent<Button>().onClick.AddListener(FartStart);

        EventTrigger.Entry entryD = new EventTrigger.Entry();
        entryD.eventID = EventTriggerType.PointerDown;
        entryD.callback.AddListener((data) => { FartStart((PointerEventData)data); });

        b.GetComponent<EventTrigger>().triggers.Add(entryD);

        EventTrigger.Entry entryU = new EventTrigger.Entry();
        entryU.eventID = EventTriggerType.PointerUp;
        entryU.callback.AddListener((data) => { FartStop((PointerEventData)data); });

        b.GetComponent<EventTrigger>().triggers.Add(entryU);

        IFartBar = Instantiate(fartBar, parent);
    }

    public void ShowUI()
    {
        IGroup = Instantiate(group, GameObject.Find("Canvas").GetComponent<RectTransform>());
        ShowGlideButton(IGroup.GetComponent<RectTransform>());
    }

    public void HideUI()
    {
        Destroy(IGroup);
    }

    //void OnGUI()
    //{
    //    GUI.Label(new Rect(0, 0, 100, 100), screenMargin.ToString());
    //    GUI.Label(new Rect(0, 50, 100, 100), (Screen.width - screenMargin).ToString());
    //    if (Input.touchCount>0)
    //    {
    //        GUI.Label(new Rect(0, 100, 100, 100), Input.GetTouch(0).position.x.ToString());
    //    }
    //}


    bool Clicked()
    {
        return true;
    }

    void FartStart(PointerEventData data)
    {
        projComp.isFarting = true;
    }

    void FartStop(PointerEventData data)
    {
        projComp.isFarting = false;
    }
}
