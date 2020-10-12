/*
 * Benjamin Schuster
 * Prototype 3
 * Spawns obstacles
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefabObstacle;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private PlayerController playerRef;


    private float spawnInterval = 2;
    private float startDelay = 2;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if(!playerRef.gameOver)
            Instantiate(prefabObstacle, spawnPosition, prefabObstacle.transform.rotation);
    }
}
