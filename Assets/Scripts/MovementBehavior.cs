using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField] protected float speed;
    public enum Direction { Left, Right }

    public Direction facing = Direction.Left;
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
