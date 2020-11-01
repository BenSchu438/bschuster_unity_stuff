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
    public bool isPaused = false;

    private string CurrentLevelName = "MainMenu";

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
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused && !CurrentLevelName.Equals("MainMenu"))
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused && !CurrentLevelName.Equals("MainMenu"))
        {
            UnPause();
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
    }

    public void UnLoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload: " + levelName);
        }
        CurrentLevelName = "MainMenu";
    }

    public void UnloadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload: " + CurrentLevelName);
        }
        CurrentLevelName = "MainMenu";
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
