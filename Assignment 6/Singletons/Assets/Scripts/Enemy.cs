/*
 * Benjamin Schuster
 * Singletons
 * Enemy Parent Class
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Enemy : MonoBehaviour, IDamageable
{
    protected float speed;
    protected int health;
    protected int damage;


    protected virtual void Awake()
    {
        speed = 10f;
        health = 100;
        damage = 20;
    }

    protected abstract void Attack(int dmg);
    public abstract void TakeDamage(int dmg);
}
