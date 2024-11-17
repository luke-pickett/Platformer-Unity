using UnityEngine;

public class FruitBehaviour : MonoBehaviour
{
    public int FruitValue = 1; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            SceneFruitCounter.Instance.AddCollectedFruit(FruitValue);

            
            GameManager.Instance.AddToTotalFruitsCollected(FruitValue);

            
            Destroy(gameObject);
        }
    }

}
