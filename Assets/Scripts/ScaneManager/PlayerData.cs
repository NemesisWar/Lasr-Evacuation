using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int _currentLevel;
    public int _levelsCompleted;
    public int[] _soldiersIndex;

    public PlayerData(SaveLoad save)
    {
        _soldiersIndex = new int[save.Squad.Count];
        _currentLevel = save.CurrentLevel;
        _levelsCompleted = save.LevelComplited;
        for (int i = 0; i < save.Squad.Count; i++)
        {
            _soldiersIndex[i] = save.Squad[i].Index;
        }
    }
}

