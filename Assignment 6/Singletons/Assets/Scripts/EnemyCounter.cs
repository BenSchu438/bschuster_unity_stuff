/*
 * Benjamin Schuster
 * Assignment 6
 * Manages amount of enemies that need to die to win in each level. Attach to empty game object in each scene
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public int enemies = 5;
    void Start()
    {
        GameManager.Instance.enemiesRemaining = enemies;
    }

}
