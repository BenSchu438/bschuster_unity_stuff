/*
* Benjamin Schuster
* Prototype 1
* Changes color of objects when crashed with player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Add script onto objects
public class CollideObjectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision coll)
    {
        //Check if collided with player
        if(coll.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
