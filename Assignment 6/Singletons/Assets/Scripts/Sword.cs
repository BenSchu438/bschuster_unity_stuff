﻿/*
 * Benjamin Schuster
 * Singletons
 * Sword Weapon 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public Camera cam;
    private float nextAttack;

    private new void Awake()
    {
        base.Awake();
        cam = GetComponentInParent<Camera>();
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
        yield return new WaitForSeconds(cooldown);
        ready = true;
        Debug.Log("Attack Recharged");
    }
}
