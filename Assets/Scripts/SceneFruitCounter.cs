using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class SceneFruitCounter : MonoBehaviour
{
    public static SceneFruitCounter Instance;

    public int FruitsCollected { get; private set; }
    public int FruitsAvailable;
    public int TotalFruitsCollected { get; private set; } 

    [SerializeField] private TextMeshProUGUI sceneCounterText;
    [SerializeField] private TextMeshProUGUI totalCounterText; 

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        SetFruitsAvailableFromScene();
        UpdateUI();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FruitsCollected = 0;

        SetFruitsAvailableFromScene();

        UpdateUI();

        if (scene.name == "GameEnd")
        {
            DisplayEndGameUI();
        }
    }

    private void SetFruitsAvailableFromScene()
    {
        GameObject[] fruits = GameObject.FindGameObjectsWithTag("Fruit");

        FruitsAvailable = fruits.Length;

        GameManager.Instance?.AddToTotalFruitsAvailable(FruitsAvailable);
    }

    public void AddCollectedFruit(int count)
    {
        FruitsCollected += count;
        TotalFruitsCollected += count; 
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

    public void ResetSceneFruitCount()
    {
        FruitsCollected = 0;
        UpdateUI();
    }


    private void DisplayEndGameUI()
    {
        if (sceneCounterText != null)
        {
            sceneCounterText.gameObject.SetActive(false);
        }

        if (totalCounterText != null)
        {
            totalCounterText.gameObject.SetActive(true);
            totalCounterText.text = $"{TotalFruitsCollected}/ 12";
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
