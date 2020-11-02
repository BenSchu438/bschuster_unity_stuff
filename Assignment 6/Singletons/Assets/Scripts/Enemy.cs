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
    //enemy stats
    protected float speed;
    protected int health;
    protected int damage;
  
    //player reference for targeting
    protected GameObject player;

    //animation stuff
    protected Animator animator;

    //audio stuff
    protected AudioSource enemyAudio;
    public AudioClip roar;

    protected virtual void Awake()
    {
        speed = 10f;
        health = 100;
        damage = 20;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected abstract IEnumerator Attack();
    protected abstract IEnumerator Move();

    //methods for taking damage and dying
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        animator.SetBool("Take Damage", true);
        Debug.Log("Ouch! Dealt " + dmg + " damage! Rude!\n" + health + " health remaining.");
        if (health <= 0)
        {
            //If dead, call coroutine to let die (for animation purposes)
            StartCoroutine(Die());
        }
    }
    protected IEnumerator Die()
    {
        speed = 0f;
        animator.SetBool("Die", true);
        yield return new WaitForSeconds(1f);

        GameManager.Instance.enemiesRemaining--;
        Destroy(gameObject);
    }

    //damage player on contact
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("touching player, should damage");
            player.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
