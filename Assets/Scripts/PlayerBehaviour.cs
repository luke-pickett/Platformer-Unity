using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : EntityBehavior
{
    private Rigidbody2D _rigidbody;
    private MovementBehavior _movementBehavior;
    
    public delegate void PlayerTakesHit();

    public static event PlayerTakesHit PlayerHit;
    
    public delegate void PlayerHasNoHealth();

    public static event PlayerHasNoHealth PlayerDied;

    private void OnEnable()
    {
        PlayerHit += HurtPlayer;
        PlayerDied += KillPlayer;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _movementBehavior = GetComponent<MovementBehavior>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            PlayerDied?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerHit?.Invoke();
        }
    }

    void KillPlayer()
    {
        Destroy(gameObject);
    }

    void HurtPlayer()
    {
        int xDirection;
        if (_movementBehavior.facing == MovementBehavior.Direction.Left)
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }
        
        DisableControls();
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(new Vector2(200 * xDirection, 300));
        health -= 1;
        Invoke("EnableControls", 2f);
    }

    void DisableControls()
    {
        _movementBehavior.enabled = false;
    }

    void EnableControls()
    {
        _movementBehavior.enabled = true;
    }
}
