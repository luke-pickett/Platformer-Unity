using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehavior : MovementBehavior
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) GetComponent<Animator>().SetBool("Running", true);
        else GetComponent<Animator>().SetBool("Running", false);

        if (Input.GetKey(KeyCode.Space)) GetComponent<Animator>().SetBool("Jumping", true);
        else GetComponent<Animator>().SetBool("Jumping", false);

    }

    private void FixedUpdate()
    {
        
    }
}
