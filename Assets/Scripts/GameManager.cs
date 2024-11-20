using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int TotalFruitsCollected { get; private set; }
    public int TotalFruitsAvailable { get; private set; }
    [SerializeField] private AudioClip collectSound; 
    private AudioSource audioSource; 

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

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void AddToTotalFruitsCollected(int count = 1)
    {
        if (collectSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collectSound);
            }
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
            endGameStatsText.text = $"{TotalFruitsCollected}/{TotalFruitsAvailable}";
        }
    }
}
