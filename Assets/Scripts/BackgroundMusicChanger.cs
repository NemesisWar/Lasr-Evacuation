using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusicChanger : MonoBehaviour
{
    [SerializeField] private AudioClip _prepareMusic;
    [SerializeField] private AudioClip _fightMusic;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        ChangeMusic(_prepareMusic);
    }

    public void PlayFightMusic()
    {
        ChangeMusic(_fightMusic);
    }

    private void ChangeMusic(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
