using UnityEngine;
using UnityEngine.SceneManagement; 

public class CheckpointBehaviour : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
    
            Time.timeScale = 0f;

            UIManager.Instance.ShowNextLevelUI(true);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UIManager.Instance.ShowNextLevelUI(false);
    }
}
