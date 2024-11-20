using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointBehaviour : MonoBehaviour
{
    [SerializeField] private AudioClip levelCompleteSound;
    private AudioSource audioSource; 

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

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
            if (levelCompleteSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(levelCompleteSound);
            }
            

            Time.timeScale = 0f;

            UIManager.Instance.ShowNextLevelUI(true);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UIManager.Instance.ShowNextLevelUI(false);
    }
}
