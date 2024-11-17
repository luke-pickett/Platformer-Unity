using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int TotalFruitsCollected { get; private set; }
    public int TotalFruitsAvailable { get; private set; }

    [SerializeField] private TextMeshProUGUI endGameStatsText; 

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

    public void AddToTotalFruitsCollected(int count = 1)
    {
        TotalFruitsCollected += count;
    }

    public void AddToTotalFruitsAvailable(int count)
    {
        TotalFruitsAvailable += count;
    }

    public void ResetGameStats()
    {
        TotalFruitsCollected = 0;
        TotalFruitsAvailable = 0;
    }

    public void DisplayEndGameStats()
    {
        if (endGameStatsText != null)
        {
            endGameStatsText.text = $"Total Fruits Collected: {TotalFruitsCollected}/{TotalFruitsAvailable}";
        }
        else
        {
            Debug.LogWarning("EndGameStatsText is not assigned in the GameManager!");
        }
    }
}
