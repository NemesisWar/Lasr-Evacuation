using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplite : MonoBehaviour
{
    [SerializeField] private int _minSavedCivilians;
    [SerializeField] private bool _destroyAll;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameOver _gameOver;

    private void OnEnable()
    {
        _spawner.SavedCivilians += OnSavedCivilians;
        _spawner.LevelFailed += OnLevelFailed;
    }

    private void OnDisable()
    {
        _spawner.SavedCivilians -= OnSavedCivilians;
        _spawner.LevelFailed -= OnLevelFailed;
    }

    private void OnSavedCivilians(int survivors)
    {
        if (_destroyAll == false && survivors >= _minSavedCivilians)
            GameIsOver(true);
        else if (_destroyAll == true && survivors <= _minSavedCivilians)
            GameIsOver(true);
        else
            GameIsOver(false);
    }

    private void OnLevelFailed()
    {
        GameIsOver(false);
    }

    private void GameIsOver(bool winLevel)
    {
        Time.timeScale = 0.1f;
        _gameOver.gameObject.SetActive(true);
        _gameOver.ActivePanel(winLevel);
        gameObject.SetActive(false);
    }

}
