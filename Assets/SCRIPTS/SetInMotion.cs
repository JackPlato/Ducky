﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInMotion : MonoBehaviour
{
    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Go()
    {
        player.go = true;
    }
}
