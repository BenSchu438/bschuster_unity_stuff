using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9;

    private int enemyCount;
    private int powerupCount;
    public int waveNumber = 1;

    //manages UI and game over
    public Text waveCounter;
    public GameObject winText;
    public bool gameOver = false;

    //Manages initial onscreen instructions
    public GameObject instructionText;
    private bool gameStart = false;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        //added in here as its only added when a new wave is added, and only 1 powerup allowed on the board at all times
        if(powerupCount != 1)
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        //Generating random position on platform
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        //start game
        if (!gameStart && Input.GetKeyDown(KeyCode.Space))
        {
            instructionText.SetActive(false);
            Time.timeScale = 1f;
            gameStart = true;
        }

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        powerupCount = GameObject.FindGameObjectsWithTag("Powerup").Length;

        if (enemyCount == 0 && gameStart)
        {
            waveNumber++;
            if (waveNumber <= 10)
            {
                SpawnEnemyWave(waveNumber);
                waveCounter.text = "Wave: " + waveNumber;
            }
        }        

        //Win when passed wave 10
        if(waveNumber > 10)
        {
            Time.timeScale = 0f;
            winText.SetActive(true);
            gameOver = true;
        }

        //reset scene on game over
        if(Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
