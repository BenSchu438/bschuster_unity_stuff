/*
 * Benjamin Schuster
 * Singletons
 * Manages verious game things
 */
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;

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

}
