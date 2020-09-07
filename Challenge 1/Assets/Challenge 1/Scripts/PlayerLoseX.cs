/*
 * Benjamin Schuster
 * Challenge 1
 * Detects if player loses by escaping map or crashing
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoseX : MonoBehaviour
{
    public Rigidbody rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //detects if player flies too high or low
        if (transform.position.y > 50 || transform.position.y < -30)
        {
            ScoreManagerX.gameOver = true;
            rigidbody.useGravity = true;
        }
    }

    //detects if player crashes into wall, game over and 'destroy' player (this is a personal touch which wasnt stated in the instructions)
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            ScoreManagerX.gameOver = true;
            ScoreManagerX.score = -100;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            rigidbody.useGravity = true;
        }
    }


}
