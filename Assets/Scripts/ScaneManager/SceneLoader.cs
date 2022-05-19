using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneLoader : MonoBehaviour
{
    public event UnityAction SaveProgress;
    public int NextLevel => _nextLevel;

    [SerializeField] private int _nextLevel;
    public void ChangeLevel()
    {
        Time.timeScale = 1f;
        SaveProgress?.Invoke();
        SceneManager.LoadScene(_nextLevel);
    }

    public void LoadMeinMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void LoadSavedGame(int level)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
    }
}
