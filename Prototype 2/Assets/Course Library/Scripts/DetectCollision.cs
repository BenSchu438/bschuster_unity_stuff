/*
 * Benjamin Schuster
 * Prototype 2
 * Decect object collisions
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Add on projectile script
public class DetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
