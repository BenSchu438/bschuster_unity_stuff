/*
 * Benjamin Schuster
 * Prototype 5
 * Controls the initialization of the target objects
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    public int scoreValue;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float  maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    private GameManager gameManager;

    public ParticleSystem explosionParticle;
    

    void Start()
    {
        //initialize
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        //Add force upwards multiplied by randomized seed
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        //add torque with randomized xyz values
        targetRb.AddTorque(
            RandomTorque(),
            RandomTorque(),
            RandomTorque(),
            ForceMode.Impulse);

        //set the position with a randomized X value
        transform.position = RandomSpawnPos();
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange) , ySpawnPos);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            gameManager.UpdateScore(scoreValue);

            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }

        Destroy(gameObject);

    }


}
