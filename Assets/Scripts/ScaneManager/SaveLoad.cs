using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public int CurrentLevel => _currentLevel;
    public int LevelComplited => _levelsCompleted;
    public List<PoliceMan> Squad => _squad;
    [SerializeField] private List<PoliceMan> _soldiersTamplate;
    private SceneLoader _sceneloader;
    private List<PoliceMan> _squad = new List<PoliceMan>();
    private int _currentLevel;
    private int _levelsCompleted;

    private void Start()
    {
        _sceneloader = GetComponent<SceneLoader>();
        _sceneloader.SaveProgress += SaveProgress;
    }

    private void Initialize()
    {
        _currentLevel = _sceneloader.NextLevel;
        _levelsCompleted = Player.LevelsCompleted;
        _squad = Player.SoldiersInSquad;
    }

    public void SaveProgress()
    {
        Initialize();
        SaveSystem.SaveProgress(this);
    }

    public void LoadProgress()
    {
        PlayerData data = SaveSystem.LoadGame();
        _currentLevel = data._currentLevel;
        _levelsCompleted = data._levelsCompleted;
        if (data._soldiersIndex.Length != 0)
        {
            for (int i = 0; i < data._soldiersIndex.Length; i++)
            {
                foreach (var soldierPrefab in _soldiersTamplate)
                {
                    if (soldierPrefab.Index == data._soldiersIndex[i])
                    {
                        _squad.Add(soldierPrefab);
                        break;
                    }
                }
            }
            Player.AddSoldiers(_squad);
        }
        Player.AppointLevel(_currentLevel, _levelsCompleted);
        LoadLastLevel(_currentLevel);
    }

    private void LoadLastLevel(int levelIndex)
    {
        _sceneloader.LoadSavedGame(levelIndex);
    }
}
