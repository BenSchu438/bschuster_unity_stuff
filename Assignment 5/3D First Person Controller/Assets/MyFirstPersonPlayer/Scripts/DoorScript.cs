/*
 * Benjamin Schuster
 * Assignment 5
 * Opens door when the linked enemies are destroyed
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    public int targetsRemaining = 1;
    public Canvas textRef;
    public Text updateMsg;

    private void Start()
    {
        updateMsg.text = "Destroy all nearby targets to pass\nTargets Remaining: " + targetsRemaining;
    }

    //can be called from targets that die. When all targets are gone, destroy this door.
    public void TargetDestroyed()
    {
        targetsRemaining--;
        if (targetsRemaining <= 0)
        {
            Destroy(textRef);
            Destroy(gameObject);
        }
        //update text on door so player knows how many targets are remaining
        updateMsg.text = "Destroy all nearby targets to pass\nTargets Remaining: " + targetsRemaining;


    }
}
