using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject _playsmentStage;
    [SerializeField] private GameObject _gameStage;
    [SerializeField] private AudioClip _clickSound;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponentInParent<AudioSource>();
    }

    public void Click()
    {
        _audioSource.PlayOneShot(_clickSound);
        _playsmentStage.SetActive(false);
        _gameStage.SetActive(true);
    }
}
