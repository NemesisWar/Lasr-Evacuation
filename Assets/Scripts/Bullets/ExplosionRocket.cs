using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ExplosionRocket : MonoBehaviour
{
    [SerializeField] private float _destroyTimer;
    private AudioSource _audioSource;
    private float _currentTime = 0;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _destroyTimer)
            Destroy(gameObject);
    }
}
