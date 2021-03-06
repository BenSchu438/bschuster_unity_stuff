﻿/*
 * Benjamin Schuster
 * Assignment 6
 * Allows player to look around (took from Assignment 5)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 10f;
    public GameObject player;
    private float verticalLookRotation = 0f;


    // Update is called once per frame
    void Update()
    {
        //Get mouse input, apply to two floats
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //rotate player gameObject with horizontal mouse input
        player.transform.Rotate(Vector3.up * mouseX);

        //rotate camera around x axis with vertical input
        verticalLookRotation -= mouseY;

        //upward look limit
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        //apply rotation to camera based on clamp
        transform.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
    }

    private void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
