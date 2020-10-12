/*
* Benjamin Schuster
* Prototype 1
* Detects collisions w/ triggerzones for score
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Add script on player
public class PlayerEnterTrigger : MonoBehaviour
{
    //If collide with triggerzone with "finish" tag, change tag to 'used' to avoid repeat collosions
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            ScoreManager.score++;
            other.tag = "used";
        }
    }
}
