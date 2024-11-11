using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public Transform SpawnPoint;
    [SerializeField] private string _nextLevel;
    private void Awake()
    {
        instance = this;
    }

    //private void Start()
    //{
    //    SpawnPoint.gameObject.SetActive(false);
    //    StartCoroutine(PlayerBehaviour.Instance.Spawn());
    //}

    //public void GoToNextLevel()
    //{
    //    SceneManager.LoadScene(_nextLevel);
    //    StartCoroutine(PlayerBehaviour.Instance.Spawn());
    //}
}
