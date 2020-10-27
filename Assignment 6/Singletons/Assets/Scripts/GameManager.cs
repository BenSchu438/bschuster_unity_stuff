/*
 * Benjamin Schuster
 * Singletons
 * Manages verious game things
 */
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

#region Singleton
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    private string currentLevelName = string.Empty;

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

    #endregion

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load: " + levelName);
            return;
        }
        currentLevelName = levelName;
    }

    public void UnLoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload: " + levelName);
        }
    }

}
