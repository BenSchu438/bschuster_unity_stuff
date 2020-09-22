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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= winScore)
        {
            gameOver = true;
            won = true;
        }

        if(gameOver && won)
        {
            Debug.Log("You Win!");
        }
        else if (gameOver)
        {
            Debug.Log("GameOver!");
        }
    }
}
