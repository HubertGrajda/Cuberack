using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Animator levelLoader;
    private const string fadeOut = "FadeOut";
    private const string fadeIn = "FadeIn";
    public enum GameState
    {
        InGame,
        Victory,
        Loss,
        InMenu,
        InPauseMenu
    }
    [NonSerialized] public bool tutorialSeen = false;

    [NonSerialized] public GameState gameState;
    [NonSerialized] public float score;

    public static GameManager Instance;
    AudioManager audioManager;
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    

        
    }
    private void Start()
    {

        Instance.audioManager = AudioManager.Instance;
        Instance.audioManager.PlaySound("MainMenuTheme");

        Instance.gameState = GameState.InMenu;
        Instance.score = 0;
    }
    
    public void EndOfTheGame()
    {
        Instance.StartCoroutine(Instance.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void PreviousLevel()
    {
        //Instance.score = 0;
        Instance.gameState = GameState.InGame;
        Instance.StartCoroutine(Instance.LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }
    public void RestartLevel()
    {
        Instance.StartCoroutine(Instance.LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }
    public void NextLevel()
    {
        Instance.gameState = GameState.InGame;
        Instance.StartCoroutine(Instance.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
   
        Instance.audioManager.StopSound("MainMenuTheme");
        Instance.audioManager.PlaySound("InGameTheme");  
    }

    public void GoToMainMenu()
    {
        Instance.gameState = GameState.InMenu;
        Instance.StartCoroutine(Instance.LoadLevel(0));
        Instance.audioManager.StopSound("InGameTheme");
        Instance.audioManager.PlaySound("MainMenuTheme");
    }
    public void QuitTheGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    
    IEnumerator LoadLevel(int sceneIndex)
    {
        levelLoader.SetTrigger(fadeOut);
        yield return new WaitForSeconds(1f);
        levelLoader.SetTrigger(fadeIn);
        
        SceneManager.LoadScene(sceneIndex);

    }
}
