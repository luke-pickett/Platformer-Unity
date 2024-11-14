using System;
using UnityEngine;

public class PlayerMovementBehavior : MovementBehavior
{
    [SerializeField] private float jumpHeight = 5f;    
    private bool isGrounded = true;                     

    private void Update()
    {
        
        float moveDirection = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1f;
            if (facing != Direction.Right)
            {
                facing = Direction.Right;
                ChangeDirection();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1f;
            if (facing != Direction.Left)
            {
                facing = Direction.Left;
                ChangeDirection();
            }
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) GetComponent<Animator>().SetBool("Running", true);
        else GetComponent<Animator>().SetBool("Running", false);

        if (Input.GetKey(KeyCode.Space) || isGrounded != true) GetComponent<Animator>().SetBool("Jumping", true);
        else GetComponent<Animator>().SetBool("Jumping", false);


        
        Rigidbody.velocity = new Vector2(moveDirection * speed, Rigidbody.velocity.y);

       
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, Mathf.Sqrt(jumpHeight * -2f * Physics2D.gravity.y));
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
