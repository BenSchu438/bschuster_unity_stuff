/*
 * Benjamin Schuster
 * Challenge 2
 * Randomly spawns balls
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    private HealthSystem healthSystem;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = GameObject.FindGameObjectWithTag("healthCore").GetComponent<HealthSystem>();

        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
        StartCoroutine(SpawnRandomBallWithCoroutine());
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[0], spawnPos, ballPrefabs[ballIndex].transform.rotation);

    }

    IEnumerator SpawnRandomBallWithCoroutine()
    {
        yield return new WaitForSeconds(startDelay);
        spawnInterval = Random.Range(3.0f, 5.0f);
        while(!healthSystem.gameOver)
        {
            SpawnRandomBall();
            spawnInterval = Random.Range(3.0f, 5.0f);
            Debug.Log(spawnInterval.ToString());
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
