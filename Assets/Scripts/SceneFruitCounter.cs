using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Required for scene loading

public class SceneFruitCounter : MonoBehaviour
{
    public static SceneFruitCounter Instance;

    public int FruitsCollected { get; private set; }
    public int FruitsAvailable;
    public int TotalFruitsCollected { get; private set; } // Total fruits collected across all scenes

    [SerializeField] private TextMeshProUGUI sceneCounterText;
    [SerializeField] private TextMeshProUGUI totalCounterText; // Optional: Display total fruits collected

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of SceneFruitCounter
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instance
            return;
        }

        Instance = this;

        // Make this object persist across scene loads
        DontDestroyOnLoad(gameObject);

        // Subscribe to scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        // Set the fruit count when the first scene is loaded
        SetFruitsAvailableFromScene();
        UpdateUI();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset the collected fruits count for the new scene
        FruitsCollected = 0;

        // Recount the fruits in the new scene
        SetFruitsAvailableFromScene();

        // Update the UI
        UpdateUI();

        // Check if it's the end game scene
        if (scene.name == "GameEnd")
        {
            DisplayEndGameUI();
        }
    }

    private void SetFruitsAvailableFromScene()
    {
        // Find all fruits in the current scene by their tag
        GameObject[] fruits = GameObject.FindGameObjectsWithTag("Fruit");

        // Update the number of available fruits
        FruitsAvailable = fruits.Length;

        // Update the total fruits available in the GameManager (if applicable)
        GameManager.Instance?.AddToTotalFruitsAvailable(FruitsAvailable);
    }

    public void AddCollectedFruit(int count)
    {
        FruitsCollected += count;
        TotalFruitsCollected += count; // Update the total count across all scenes
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (sceneCounterText != null)
        {
            sceneCounterText.text = $" {FruitsCollected}/{FruitsAvailable}";
        }

        if (totalCounterText != null)
        {
            totalCounterText.text = $"Total: {TotalFruitsCollected}";
        }
    }

    private void DisplayEndGameUI()
    {
        // Optionally disable the scene counter UI
        if (sceneCounterText != null)
        {
            sceneCounterText.gameObject.SetActive(false);
        }

        // Optionally enable a final total count display
        if (totalCounterText != null)
        {
            totalCounterText.gameObject.SetActive(true);
            totalCounterText.text = $"{TotalFruitsCollected}/ 12";
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
