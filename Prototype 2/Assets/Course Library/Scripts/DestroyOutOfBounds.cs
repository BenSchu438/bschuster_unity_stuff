/*
 * Benjamin Schuster
 * Prototype 2
 * Destroy non-player objects when out of bounds
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Add to animal and food
public class DestroyOutOfBounds : MonoBehaviour
{
    //Food and animals exit off seperate sides of screen, so topbound is for food and bottombound is for animals
    public float topBound = 20;
    public float bottomBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //food out of bounds
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        //animal out of bounds
        if(transform.position.z < bottomBound)
        {
            GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>().TakeDamage();

            Destroy(gameObject);
        }
    }
}
