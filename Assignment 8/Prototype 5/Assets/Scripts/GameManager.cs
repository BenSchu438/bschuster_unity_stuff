/*
 * Benjamin Schuster
 * Prototype 5
 * Game manager, spawns items 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnRate = 1.5f;

    public GameObject titleScreen;
    public TextMeshProUGUI scoreText;
    private int score;

    public TextMeshProUGUI loseText;
    public TextMeshProUGUI winText;

    public bool isGameActive;
    public GameObject restartButton;


    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        titleScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);

        spawnRate = 1.0f / difficulty;
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            //wait 1 second
            yield return new WaitForSeconds(spawnRate);

            //Select one random object from list and spawn
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score;
        if(score >= 100)
        {
            GameWin();
        }
    }

    public void GameOver()
    {
        if(isGameActive)
        {
            isGameActive = false;
            loseText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
        
    }
    public void GameWin()
    {
        if(isGameActive)
        {
            isGameActive = false;
            winText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    

}
