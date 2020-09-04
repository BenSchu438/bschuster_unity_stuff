using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
