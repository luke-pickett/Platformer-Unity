using UnityEngine;
using UnityEngine.SceneManagement;  // Required to detect scene loading

public class CheckpointBehaviour : MonoBehaviour
{
    private void Awake()
    {
        // Subscribe to the scene loaded event to hide the nextLevelUI
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Pause the game when reaching the checkpoint
            Time.timeScale = 0f;

            // Activate the next level UI using the UIManager
            UIManager.Instance.ShowNextLevelUI(true);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Hide the next level UI each time a new scene is loaded
        UIManager.Instance.ShowNextLevelUI(false);
    }
}
