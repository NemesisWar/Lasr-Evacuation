using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPrepare : MonoBehaviour
{
    [SerializeField] private GameObject _preparePanel;
    [SerializeField] private GameObject _game;
    [SerializeField] private AudioClip _clickSound;
    private Squad _squad;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponentInParent<AudioSource>();
        _squad = GetComponentInParent<Squad>();
    }
    public void TranferToGame()
    {
        _audioSource.PlayOneShot(_clickSound);
        Player.TransferSquad(_squad.CurrentSquad());
        _game.SetActive(true);
        _preparePanel.SetActive(false);
    }
}
