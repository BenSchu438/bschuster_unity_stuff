/*
* Benjamin Schuster
* Challenge 1
* Manages player score, if game was won/lost, and restarting the game
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManagerX : MonoBehaviour
{
    public static bool gameOver;
    public static bool win;
    public static int score;
    public Text textbox;

    void Start()
    {
        gameOver = false;
        win = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            textbox.text = "Score: " + score;
        }

        if (score >= 5)
        {
            win = true;
            gameOver = true;
        }
        if (gameOver)
        {
            if (win)
            {
                textbox.text = "You Win!\nPress R to Try Again!";
            }
            else
            {
                textbox.text = "You lose!\nPress R to Try Again!";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
