using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float _destroyTime;
    private float _currentTime;

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
