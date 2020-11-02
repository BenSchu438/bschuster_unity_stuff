/*
 * Benjamin Schuster
 * Singletons
 * Parent for weapons
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Weapon: MonoBehaviour
{
    protected int damage;
    protected float range;
    protected float cooldown;
    protected bool ready;

    protected void Awake()
    {
        damage = 30;
        range = 6f;
        cooldown = 0.7f;
        ready = true;
    }

    public abstract void Attack();
    protected abstract IEnumerator Recharge();
    
}
