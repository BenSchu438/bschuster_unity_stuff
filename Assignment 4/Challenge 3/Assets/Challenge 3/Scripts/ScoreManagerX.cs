/*
 * Benjamin Schuster
 * Challenge 3
 * Manage score and scene restart
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManagerX : MonoBehaviour
{
    public int score = 0;
    public int winScore;
    public bool gameOver = false;
    public bool won = false;

    public GameObject loseText;
    public GameObject winText;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;

        if(score >= winScore)
        {
            gameOver = true;
            won = true;
        }

        
        if(gameOver && won)
        {
            winText.SetActive(true);
        }
        else if (gameOver)
        {
            loseText.SetActive(true);
        }

        if(gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        
    }
}
