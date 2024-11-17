using UnityEngine;
using TMPro;

public class SceneFruitCounter : MonoBehaviour
{
    public static SceneFruitCounter Instance;

    public int FruitsCollected { get; private set; }
    public int FruitsAvailable;

    [SerializeField] private TextMeshProUGUI sceneCounterText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddCollectedFruit(int count)
    {
        FruitsCollected += count;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (sceneCounterText != null)
        {
            sceneCounterText.text = $" {FruitsCollected}/{FruitsAvailable}";
        }
    }

    public void SetFruitsAvailable(int count)
    {
        FruitsAvailable = count;
        GameManager.Instance.AddToTotalFruitsAvailable(count);
        UpdateUI();
    }
}
