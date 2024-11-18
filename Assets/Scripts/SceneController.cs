using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance; // Singleton instance

    [SerializeField] private Button nextLevelButton;
    [SerializeField] private GameObject nextLevelUI;
    [SerializeField] private GameObject fruitDisplayUI; // Reference to the FruitDisplay UI
    [SerializeField] private GameObject endGameUI;      // Reference to the EndGame UI

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

    private void Start()
    {
        UpdateUIForCurrentScene();
    }

    private void UpdateUIForCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "GameEnd")
        {
            // Disable FruitDisplay UI and enable EndGame UI
            if (fruitDisplayUI != null) fruitDisplayUI.SetActive(false);
            if (endGameUI != null) endGameUI.SetActive(true);
        }
        else
        {
            // Default: Enable FruitDisplay UI and disable EndGame UI
            if (fruitDisplayUI != null) fruitDisplayUI.SetActive(true);
            if (endGameUI != null) endGameUI.SetActive(false);

            UpdateNextLevelButton();
        }
    }

    private void UpdateNextLevelButton()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        string nextLevel = GetNextLevelName(currentScene);

        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.RemoveAllListeners();
            if (nextLevel != null)
            {
                nextLevelButton.onClick.AddListener(() => LoadNextLevel(nextLevel));
            }
            else
            {
                nextLevelButton.onClick.AddListener(() => Debug.Log("No more levels!"));
            }
        }
    }

    private string GetNextLevelName(string currentScene)
    {
        switch (currentScene)
        {
            case "Level-1":
                return "Level-2";
            case "Level-2":
                return "Level-3";
            case "Level-3":
                return "GameEnd";
            default:
                return null;
        }
    }

    public void LoadNextLevel(string nextLevel)
    {
        if (nextLevelUI != null)
        {
            nextLevelUI.SetActive(false);
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene(nextLevel);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateUIForCurrentScene();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
