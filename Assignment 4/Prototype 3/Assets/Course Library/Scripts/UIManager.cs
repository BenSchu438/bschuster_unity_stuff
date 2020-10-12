/*
 * Benjamin Schuster
 * Prototype 3
 * Manages UI
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    public PlayerController playerRef;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
            scoreText = FindObjectOfType<Text>();

        if (playerRef == null)
            playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerRef.gameOver)
            scoreText.text = "Score: " + score;

        if (playerRef.gameOver && !won)
            scoreText.text = "You Lose! \nPress R to Try Again!";

        if(score >= 10)
        {
            playerRef.gameOver = true;
            won = true;

            scoreText.text = "You Win! \nPress R to Try Again!";
        }

        if(playerRef.gameOver && Input.GetKeyDown(KeyCode.R) )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
