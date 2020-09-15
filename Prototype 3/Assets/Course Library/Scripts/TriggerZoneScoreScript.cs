/*
 * Benjamin Schuster
 * Prototype 3
 * Add score to player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneScoreScript : MonoBehaviour
{
    private UIManager scoreRef;
    private bool scored = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreRef = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered!");

        if(other.gameObject.CompareTag("Player") && !scored)
        {
            scored = true;
            scoreRef.score++;
        }
    }
}
