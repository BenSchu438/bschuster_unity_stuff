/*
 * Benjamin Schuster
 * Prototype 4
 * Manages score and game completion 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoreRef;
    public GameObject winTextRef;
    public bool gameOver = false;
    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreRef.text = "Score: " + score;

        if(gameOver)
        {
            winTextRef.SetActive(true);
        }

        if(gameOver && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
