using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    // Update is called once per frame
    private float horizontalInput;
    private float forwardInput;
    public float speed;
    public float turnSpeed;

    void Update()
    {
        
        //Get inputs
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Move player forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        //Rotate player
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);

        
    }


}
