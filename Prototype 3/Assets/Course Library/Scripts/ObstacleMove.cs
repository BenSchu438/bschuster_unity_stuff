/*
 * Benjamin Schuster
 * Prototype 3
 * Move obstacle to left
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float speed;
    private float leftBound = -15;

    private PlayerController playerRef;
    private UIManager scoreRef;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        scoreRef = GameObject.FindGameObjectWithTag("GameController").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerRef.gameOver)
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x < leftBound && gameObject.CompareTag("obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
