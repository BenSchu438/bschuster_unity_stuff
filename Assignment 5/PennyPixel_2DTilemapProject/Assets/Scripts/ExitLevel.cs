/*
 * Benjamin Schuster
 * Prototype 4
 * Triggers game win on exiting the level 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    private Score gameOverRef;

    // Start is called before the first frame update
    void Start()
    {
        gameOverRef = GameObject.FindGameObjectWithTag("GameController").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("At End");
        if(other.CompareTag("Player"))
        {
            gameOverRef.gameOver = true;
        }
    }
}
