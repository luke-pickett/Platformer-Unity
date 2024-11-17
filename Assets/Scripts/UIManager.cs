using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    [SerializeField] private GameObject nextLevelButton;  // Reference to the button
    private Button buttonComponent;

    private void Awake()
    {
        // Check if the instance already exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy the duplicate
            return;
        }

        // Set this instance as the single one
        instance = this;
        DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed on scene load

        // Optionally, initialize the button component if it exists
        if (nextLevelButton != null)
        {
            buttonComponent = nextLevelButton.GetComponent<Button>();
        }
    }

    private void Start()
    {
        // Optionally add listeners or other logic for the UI
        if (buttonComponent != null)
        {
            buttonComponent.onClick.AddListener(HandleNextLevel);
        }
    }

    private void HandleNextLevel()
    {
        // Logic to handle button click, like loading the next level
        Debug.Log("Loading next level...");
    }
}
