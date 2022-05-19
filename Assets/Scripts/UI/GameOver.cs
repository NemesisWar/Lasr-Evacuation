using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _winGame;
    [SerializeField] private GameObject _looseGame;

    public void ActivePanel(bool resultGame)
    {
        if (resultGame == true)
            _winGame.SetActive(true);
        else
            _looseGame.SetActive(true);
    }
}
