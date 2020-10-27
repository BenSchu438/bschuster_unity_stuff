/*
 * Benjamin Schuster
 * Singletons
 * Golem, child of enemy class
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region Singleton Code
public class Golem : Enemy
{
    protected int damage;
    private string currentLevelName = string.Empty;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        health = 150;
        damage = 30;
        GameManager.instance.score += 5;
    }
    protected override void Attack(int dmg)
    {
        Debug.Log("Golem Attack");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(int dmg)
    {
        Debug.Log("Ouch! Dealt " + dmg + " damage! Rude!");
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
