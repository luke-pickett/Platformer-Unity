using UnityEngine;

public class PlayerMovementBehavior : MovementBehavior
{
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float fallingGravityScale = 2f; 
    [SerializeField] private AudioClip jumpSound; 
    private AudioSource audioSource; 
    private bool isGrounded = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

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

        GetComponent<Animator>().SetBool("Running", Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));

        GetComponent<Animator>().SetBool("Jumping", !isGrounded || Input.GetKey(KeyCode.Space));

        Rigidbody.velocity = new Vector2(moveDirection * speed, Rigidbody.velocity.y);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, Mathf.Sqrt(jumpHeight * -2f * Physics2D.gravity.y));
            isGrounded = false;
            audioSource.PlayOneShot(jumpSound);
      
        }

        if (Rigidbody.velocity.y > 0)
        {
            Rigidbody.gravityScale = baseGravityScale;
        }
        else if (Rigidbody.velocity.y < 0)
        {
            Rigidbody.gravityScale = fallingGravityScale; 
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
