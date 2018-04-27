using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    [SerializeField]
    string FirstScene;

    [SerializeField]
    public LauncherStats currLauncher;

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

}
