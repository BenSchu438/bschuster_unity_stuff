/*
 * Benjamin Schuster
 * Singletons
 * Manages verious game things
 */
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    public GameObject pauseMenu;
    public GameObject loseMenu;
    public GameObject winMenu;

    public bool isPaused = false;

    private string CurrentLevelName = "MainMenu";

    //Win condition variable. Set to 99 in menu, reduced to appropriate levels once loaded into level
    public int enemiesRemaining = 99;

    public bool gameOver = false;
    public bool gameWon = false;

    /*#region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            //Make sure game manager is global
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instantiate second singleton");
        }
    }

    #endregion*/

    private void Update()
    {
        //pauses and resumes on esc press. Cannot pause on main menu screen
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused && !CurrentLevelName.Equals("MainMenu") && !gameOver)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused && !CurrentLevelName.Equals("MainMenu") && !gameOver)
        {
            UnPause();
        }


        if(enemiesRemaining <= 0)
        {
            gameOver = true;
            gameWon = true;
        }

        if (gameOver && gameWon)
        {
            //Debug.Log("Opened Win Menu");
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            winMenu.SetActive(true);
        }
        else if(gameOver && !gameWon)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            loseMenu.SetActive(true);
        }
    }

    //load and unload levels
    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load: " + levelName);
            return;
        }
        CurrentLevelName = levelName;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnLoadLevel(string levelName)
    {
        //as exiting level, reset win conditions
        gameOver = false;
        gameWon = false;
        GameManager.Instance.enemiesRemaining = 99;

        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload: " + levelName);
        }
        CurrentLevelName = "MainMenu";
        Cursor.lockState = CursorLockMode.None;
    }

    public void UnloadCurrentLevel()
    {
        //as exiting level, reset win conditions
        gameOver = false;
        gameWon = false;
        GameManager.Instance.enemiesRemaining = 99;

        AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload: " + CurrentLevelName);
        }
        CurrentLevelName = "MainMenu";
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        //as exiting level, reset win conditions
        gameOver = false;
        gameWon = false;
    }

    public void ReloadCurrentLevel()
    {
        string temp = CurrentLevelName;
        UnloadCurrentLevel();
        LoadLevel(temp);
        Cursor.lockState = CursorLockMode.Locked;
    }

    //pausing and unpausing
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPaused = true;
    }
    public void UnPause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

}
