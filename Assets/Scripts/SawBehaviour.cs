using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _targetObject;
    [SerializeField] private float _timeToReachTarget;
    private Vector3 _targetPosition;
    private Vector3 _startPosition;
    private float _timeElapsed;

    private void Start()
    {
        _targetObject.SetActive(false);
        _targetPosition = _targetObject.transform.position;
        _startPosition = transform.position;
    }

    private void Update()
    {
        _timeElapsed += Time.deltaTime;
        float interpolation = _timeElapsed / _timeToReachTarget;
        transform.position = Vector3.Lerp(_startPosition, _targetPosition, _timeElapsed / _timeToReachTarget);
        if (interpolation >= 1)
        {
            Vector3 temp = _startPosition;
            _startPosition = _targetPosition;
            _targetPosition = temp;
            _timeElapsed = 0;

        }
    }
}
