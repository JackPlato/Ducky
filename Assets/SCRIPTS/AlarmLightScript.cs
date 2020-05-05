using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLightScript : MonoBehaviour
{
    public float spin = 230.0f;
    public GameObject lightOne, lightTwo;

    void Start()
    {
        
    }

    void Update()
    {
        lightOne.transform.RotateAround(transform.position, Vector3.up, spin * Time.deltaTime);
        lightTwo.transform.RotateAround(transform.position, Vector3.up, spin * Time.deltaTime);
    }
}
