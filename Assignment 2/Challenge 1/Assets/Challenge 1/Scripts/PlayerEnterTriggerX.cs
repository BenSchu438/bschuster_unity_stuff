/*
 * Benjamin Schuster
 * Challenge 1
 * Triggerzone for score
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterTriggerX : MonoBehaviour
{
    private bool trigger = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!trigger && other.CompareTag("Player"))
        {
            trigger = true;
            ScoreManagerX.score++;
        }
    }
}
