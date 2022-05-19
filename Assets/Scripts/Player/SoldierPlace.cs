using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoldierPlace : MonoBehaviour
{
    public event UnityAction PlaceIsTaken;
    [SerializeField] private ParticleSystem _spawnEffect;
    [SerializeField] private AudioClip _clickSound;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponentInParent<AudioSource>();
    }

    public void Init(GameObject soldier)
    {
        _audioSource.PlayOneShot(_clickSound);
        soldier.transform.position = transform.position;
        PlaceIsTaken?.Invoke();
        Instantiate(_spawnEffect, transform.position, Quaternion.identity);
        Disable();
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
