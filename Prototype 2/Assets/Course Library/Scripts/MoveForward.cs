/*
 * Benjamin Schuster
 * Prototype 2
 * Controls movement for non-player objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Add this script on non-player entities
public class MoveForward : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
