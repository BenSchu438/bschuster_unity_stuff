/*
 * Benjamin Schuster
 * Singletons
 * Generic Singleton template
 */
using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get { return instance; }
    }

    public static bool IsInitialized
    {
        get { return instance != null;  }
    }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("[Singleton] Trying to instantiate a second instance of itself");
        }
        else
        {
            instance = (T)this;
        }
           
    }
    protected virtual void OnDestroy()
    {
        //if destroyed, clear instance for others to occupy
        if (Instance == this)
        {
            instance = null;
        }

    }

}


