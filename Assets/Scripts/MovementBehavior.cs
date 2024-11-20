using System;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float baseGravityScale = 1.5f; 

    public enum Direction { Left, Right }
    public Direction facing = Direction.Left;

    protected Rigidbody2D Rigidbody;
    protected SpriteRenderer SpriteRenderer;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();

        if (Rigidbody != null)
        {
            Rigidbody.gravityScale = baseGravityScale; 
        }
        
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
