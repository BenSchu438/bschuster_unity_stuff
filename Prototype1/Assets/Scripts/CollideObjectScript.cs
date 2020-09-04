using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideObjectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
