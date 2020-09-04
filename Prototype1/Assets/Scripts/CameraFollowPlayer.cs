/*
* Benjamin Schuster
* Prototype 1
* Binds camera to player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Add script onto camera
public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;

    //Distance camera is from player
    private Vector3 offset = new Vector3(0, 10, -10);

    // Update is called once per frame
    void Update()
    {
        //Move camera
        transform.position = player.transform.position + offset;
    }
}
