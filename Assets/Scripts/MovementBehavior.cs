using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected enum Direction { Left, Right }

    protected Direction Facing = Direction.Left;
    protected Rigidbody2D Rigidbody;
    protected SpriteRenderer SpriteRenderer;


    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void ChangeDirection()
    {
        if (SpriteRenderer.flipX)
        {
            SpriteRenderer.flipX = false;
        }
        else
        {
            SpriteRenderer.flipX = true;
        }
    }
}
