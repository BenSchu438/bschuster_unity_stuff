/*
 * Benjamin Schuster
 * Singletons
 * Sword Weapon 
 */
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;

public class Sword : Weapon
{
    public Camera cam;
    protected float nextAttack;
    protected Animator animator;

    //sound effects
    protected AudioSource swordAudio;
    public AudioClip swing;

    protected override void Awake()
    {
        base.Awake();
        cam = GetComponentInParent<Camera>();
        animator = GetComponent<Animator>();
        swordAudio = GetComponent<AudioSource>();
    }

    public override void Attack()
    {
        RaycastHit hitInfo;
        if (ready && Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
        {
            //get target script off object
            Enemy target = hitInfo.transform.gameObject.GetComponent<Enemy>();
            //deal damage if valid target
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            //if (hitInfo.rigidbody != null)
            //{
            //    hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            //}
            ready = false;
            swordAudio.PlayOneShot(swing);
            StartCoroutine(Recharge());
        }
        else if (ready)
        {
            ready = false;
            StartCoroutine(Recharge());
        }
    }

    protected override IEnumerator Recharge()
    {
        animator.SetBool("Swing", true);
        yield return new WaitForSeconds(cooldown);
        ready = true;
        animator.SetBool("Swing", false);
        Debug.Log("Attack Recharged");
    }
}
