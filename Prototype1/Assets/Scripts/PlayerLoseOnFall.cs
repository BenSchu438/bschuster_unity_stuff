/*
* Benjamin Schuster
* Prototype 1
* Detects if player fell off map
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Add script to player
public class PlayerLoseOnFall : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //check loss condition
        if(transform.position.y < -1)
        {
            ScoreManager.gameOver = true;
        }
    }
}
