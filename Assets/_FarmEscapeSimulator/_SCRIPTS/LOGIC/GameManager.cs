using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    private static GameManager _instance;

    public static GameManager Instance {get {return _instance;}}


    [SerializeField]
    string FirstScene;

    [SerializeField]
    GameObject[] projectiles;

    [SerializeField]
    public LauncherStats currLauncher;

    [SerializeField]
    GameObject Controller;

    private AnimalController currController;

    public PlayerPrefs CurrPlayer;

    public enum GameState : short { MainMenu, BaseGameMode }

    public GameState activeGameState;

    public GameState ActiveGameState
    {
        get
        {
            return activeGameState;
        }

        set
        {
            activeGameState = value;
        }
    }

    public LauncherStats CurrLauncher
    {
        get
        {
            return currLauncher;
        }

        set
        {
            currLauncher = value;
        }
    }

    public AnimalController CurrController
    {
        get
        {
            return currController;
        }

        set
        {
            currController = value;
        }
    }

    void Awake()
    {
        if (Instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        CurrPlayer = new PlayerPrefs();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadScene(FirstScene);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }

    private void Update()
    {
        if (Input.GetKeyDown("r")) LoadScene("GameScene");
    }

    #region Sets
    public void SetProjectile(GameObject proj)
    {
        currLauncher.projectile = proj;
    }

    public void SetProjectile(int x)
    {
        currLauncher.projectile = projectiles[x] ;
    }

    public void SetProjectile(Dropdown x)
    {
        currLauncher.projectile = projectiles[x.value];
    }

    public void SetArmSpeed(float value)
    {
        currLauncher.speed = value;
    }

    public void SetLaunchPower(float value)
    {
        currLauncher.lPower = value;
    }

    public void SetDeviationAngle(float value)
    {
        currLauncher.deviationAngle = value;
    }

    public void SetMaxSpins(float value)
    {
        currLauncher.maxSpins = value;
    }

    public void SetLaunchTime(float value)
    {
        currLauncher.launchTime = value;
    }

    public void SetLaunchTime(Text value)
    {
        currLauncher.launchTime = float.Parse(value.text);
    }

    public void SetArmSpeed(Text value)
    {
        currLauncher.speed = float.Parse(value.text);
    }

    public void SetLaunchPower(Text value)
    {
        currLauncher.lPower = float.Parse(value.text);
    }

    public void SetDeviationAngle(Text value)
    {
        currLauncher.deviationAngle = float.Parse(value.text);
    }

    public void SetMaxSpins(Text value)
    {
        currLauncher.maxSpins = float.Parse(value.text);
    }
    #endregion 

    public void SpawnAnimalController(GameObject anima)
    {
        currController = Instantiate(Controller, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<AnimalController>();
        currController.SetAnimal(anima);
    }

    public void DestroyController()
    {
        if(currController != null)
        {
            Destroy(currController.gameObject);
        }
    }

    public void TurnOnGlider()
    {
        if(Instance.currController!=null)
            Instance.currController.TurnOnGlider();
    }
}
