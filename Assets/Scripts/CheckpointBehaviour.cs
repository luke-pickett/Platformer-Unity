using UnityEngine;

public class CheckpointBehaviour : MonoBehaviour
{
    public GameObject nextLevelUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            Time.timeScale = 0f;

            
            if (nextLevelUI != null)
            {
                nextLevelUI.SetActive(true);
            }
            
        }
    }
}
