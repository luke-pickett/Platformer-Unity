using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Button nextLevelButton; 

    private void Start()
    {
        UpdateNextLevelButton();
    }

    private void UpdateNextLevelButton()
    {
        
        string currentScene = SceneManager.GetActiveScene().name;

        
        string nextLevel = GetNextLevelName(currentScene);

        if (nextLevel != null)
        {
            nextLevelButton.onClick.RemoveAllListeners(); 
            nextLevelButton.onClick.AddListener(() => LoadNextLevel(nextLevel));
        }
    }

    private string GetNextLevelName(string currentScene)
    {
        // Example: Update this with your scene names
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

    private void LoadNextLevel(string nextLevel)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextLevel);
    }
}
