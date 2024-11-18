using System;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class PlayerBehaviour : EntityBehavior
{
    private Rigidbody2D _rigidbody;
    private MovementBehavior _movementBehavior;

    public delegate void PlayerTakesHit();
    public static event PlayerTakesHit PlayerHit;

    public delegate void PlayerHasNoHealth();
    public static event PlayerHasNoHealth PlayerDied;

    public Transform spawnPoint;

    private void OnEnable()
    {
        PlayerHit += HurtPlayer;
        PlayerDied += KillPlayer;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _movementBehavior = GetComponent<MovementBehavior>();

        DontDestroyOnLoad(gameObject);
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetSpawnPointForScene(scene.name);

        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;
        }
    }

    private void SetSpawnPointForScene(string sceneName)
    {
        switch (sceneName)
        {
            case "Level-1":
                spawnPoint = GameObject.Find("SpawnPoint1")?.transform;
                break;

            case "Level-2":
                spawnPoint = GameObject.Find("SpawnPoint2")?.transform;
                break;

            case "Level-3":
                spawnPoint = GameObject.Find("SpawnPoint3")?.transform;
                break;

            case "GameEnd":
                spawnPoint = GameObject.Find("SpawnPoint4")?.transform;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerHit?.Invoke();
        }
    }
}
