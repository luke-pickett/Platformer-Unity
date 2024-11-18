using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // Singleton instance

    [SerializeField] private GameObject nextLevelUI; // UI for the next level

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ShowNextLevelUI(bool show)
    {
        if (nextLevelUI != null)
        {
            nextLevelUI.SetActive(show);
        }
    }
}
