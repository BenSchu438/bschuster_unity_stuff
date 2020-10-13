﻿/*
 * Benjamin Schuster
 * Assignment 5
 * Manage firing the weapon
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithRaycast : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera cam;

    public ParticleSystem muzzelFlash;

    public float hitForce = 10f;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzelFlash.Play();

        RaycastHit hitInfo;
         if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
         {
            Debug.Log(hitInfo.transform.gameObject.name);

            //get target script off object
            Target target = hitInfo.transform.gameObject.GetComponent<Target>();
            //deal damage if valid target
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
         }

    }
}
