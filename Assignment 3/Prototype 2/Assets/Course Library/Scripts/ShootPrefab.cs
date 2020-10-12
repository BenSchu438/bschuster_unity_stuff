/*
 * Benjamin Schuster
 * Prototype 2
 * Fire prefab objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Add this script to player
public class ShootPrefab : MonoBehaviour
{
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
        }
    }
}
