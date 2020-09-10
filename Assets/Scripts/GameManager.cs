using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        PREGAME,
        RUNNING,
        PAUSED
    }

    private bool isDead;
    private int highScore, gameScore;
    private string currentLevelName = string.Empty;
    GameState currentGameState = GameState.PREGAME;

    public GameState CurrentGameState
    {
        get {return currentGameState; }
        private set { currentGameState = value; }
    }

    #region Singleton
    public static GameManager instance;

    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("[GameManager] trying to create another instance");
            return;
        }
        instance = this;
    }
    #endregion

    private void Start() 
    {
        SetHighScore(100);
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if(currentGameState == GameState.PREGAME)
        {
            return;
        }    

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void UpdateState(GameState state)
    {
        GameState previousGameState = currentGameState;
        currentGameState = state;

        switch (currentGameState)
        {
            case GameState.PREGAME:
                Time.timeScale = 1.0f;
                break;
            case GameState.RUNNING:
                Time.timeScale = 1.0f;
                break;
            case GameState.PAUSED:
                Time.timeScale = 0.0f;
                break;
            default:
                break;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Start Menu");
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void LoadLevelName(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void TogglePause()
    {
        UpdateState(currentGameState == GameState.RUNNING ? GameState.PAUSED : GameState.RUNNING);
    }

    public void SetScore(int score)
    {
        gameScore = score;
        if(gameScore > GetHighScore())
        {
            SetHighScore(gameScore);
        }
    }

    public int GetScore()
    {
        return gameScore;
    }

    public bool IsGamePaused()
    {
        if(currentGameState == GameState.PAUSED)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool didPlayerDie()
    {
        return isDead;
    }

    public void isPlayerDead(bool isDeadFromPlayer)
    {
        isDead = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetHighScore(int value)
    {
        PlayerPrefs.SetInt("High Score", value);
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("High Score");
    }
}
