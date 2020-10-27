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

    [SerializeField] protected Weapon weapon;

    protected virtual void Awake()
    {
        weapon = gameObject.AddComponent<Weapon>();

        speed = 5f;
        health = 100;

        weapon.damageBonus = 20;
    }

    protected abstract void Attack(int dmg);
    public abstract void TakeDamage(int dmg);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
