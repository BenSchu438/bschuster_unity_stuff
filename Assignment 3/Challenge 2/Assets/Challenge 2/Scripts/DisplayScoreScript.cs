/*
 * Benjamin Schuster
 * Challenge 2
 * Controls score and win condition
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayScoreScript : MonoBehaviour
{
    public Text textbox;
    public int score;
    public GameObject winText;
    private HealthSystem healthSystem;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = GameObject.FindGameObjectWithTag("healthCore").GetComponent<HealthSystem>();
        textbox = GetComponent<Text>();
        textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = "Score: " + score;

        if(score >= 5)
        {
            healthSystem.gameOver = true;
            winText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
