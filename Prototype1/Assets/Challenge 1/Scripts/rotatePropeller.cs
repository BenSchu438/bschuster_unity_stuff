/*
 * Benjamin Schuster
 * Challenge 1
 * Rotates propeller
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePropeller : MonoBehaviour
{

    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        //Makes propeller stop if game over bc of crash
        if(!ScoreManagerX.gameOver || ScoreManagerX.win)
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        else
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
