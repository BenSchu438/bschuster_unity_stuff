/*
 * Benjamin Schuster
 * Assignment 7 Challenge 4
 * Spawns enemies and manages gameover 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRangeX = 10;
    private float spawnZMin = 15; // set min spawn Z
    private float spawnZMax = 25; // set max spawn Z

    public int enemyCount;
    public int enemySpeed = 6;
    public int waveCount = 0;

    public GameObject player;

    public bool gameOver = false;
    private bool gameWon = false;
    private bool gameStart = false;
    public Text waveText;
    public GameObject winText;
    public GameObject loseText;
    public GameObject instructions;

    //Set max waves, for the sake of testing, and that 10 waves for this game seems like a bit much
    public int maxWaves = 5;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //when pressing space at start of game, unpause game and start
        if(!gameStart && Input.GetKeyDown(KeyCode.Space))
        {
            instructions.SetActive(false);
            Time.timeScale = 1f;
            gameStart = true;
        }

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        //Update wave and text aslong as not past maxwaves
        if (enemyCount == 0 && gameStart && !gameOver)
        {
            if (waveCount <= maxWaves)
            {
                enemySpeed = 6 + waveCount;

                SpawnEnemyWave(waveCount);
                waveText.text = "Wave: " + waveCount +" out of " + maxWaves;

                waveCount++;
            }
            else
            {
                gameWon = true;
                gameOver = true;
            }
        }

        if(gameOver)
        {
            Time.timeScale = 0f;
            if (gameWon)
                winText.SetActive(true);
            else
                loseText.SetActive(true);
        }

        if (gameOver && Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    // Generate random spawn position for powerups and enemy balls
    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }


    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end

        // If no powerups remain, spawn a powerup
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

        ResetPlayerPosition(); // put player back at start
    }

    // Move player back to position in front of own goal
    void ResetPlayerPosition ()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

}
