/*
 * Benjamin Schuster
 * Challenge 1
 * Links camera to player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//add script to camera
public class FollowPlayerX : MonoBehaviour
{
    //offset was not set to anything
    public GameObject plane;
    private Vector3 offset = new Vector3(30,0,0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}
