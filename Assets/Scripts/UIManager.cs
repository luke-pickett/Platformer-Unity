using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; 

    [SerializeField] private GameObject nextLevelUI;

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
