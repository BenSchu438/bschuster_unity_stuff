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
    protected float minDistance;
    [SerializeField]
    protected GameObject player;


    protected virtual void Awake()
    {
        speed = 10f;
        health = 100;
        damage = 20;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected abstract void Attack(int dmg);
    protected abstract IEnumerator Move();
    public abstract void TakeDamage(int dmg);
}
