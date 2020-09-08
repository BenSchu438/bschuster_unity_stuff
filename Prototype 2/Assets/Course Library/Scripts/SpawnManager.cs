/*
 * Benjamin Schuster
 * Prototype 2
 * Manages creation of animals
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Add to empty object
public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;

    private float bound = 14;
    private float spawnPosZ = 20;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomPrefab", 2, 1.5f);

        StartCoroutine(SpawnRandomPrefabWithCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {
            //v1 - spawn object
            Instantiate(prefabsToSpawn[0], new Vector3(0, 0, 20), prefabsToSpawn[0].transform.rotation);

            //v2 - spawn random object
            int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

            Instantiate(prefabsToSpawn[prefabIndex], new Vector3(0, 0, 20), prefabsToSpawn[prefabIndex].transform.rotation);
        }
    */
    }

    IEnumerator SpawnRandomPrefabWithCoroutine()
    {
        yield return new WaitForSeconds(3f);

        while(!gameOver)
        {
            SpawnRandomPrefab();
            yield return new WaitForSeconds(1.5f);
        }
    }

    void SpawnRandomPrefab()
    {
            int prefabIndex = Random.Range(0, prefabsToSpawn.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-bound, bound), 0, spawnPosZ);
            Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }
}
