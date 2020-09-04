/*
* Benjamin Schuster
* Prototype 1
* Manages player score, if game was won/lost, and restarting the game
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Add script on any object in scene (I chose eventsystem)
public class ScoreManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool won;
    public static int score;

    public Text textbox;
    // Update is called once per frame

    void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
    }
    void Update()
    {
        if( !gameOver)
        {
            textbox.text = "Score: " + score;
        }

        if(score >= 3)
        {
            won = true;
            gameOver = true;
        }
        if(gameOver)
        {
            if(won)
            {
                textbox.text = "You Win!\nPress R to Try Again!";
            }
            else
            {
                textbox.text = "You lose!\nPress R to Try Again!";
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
