using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    public static List<PoliceMan> SoldiersInSquad => _soldiersInSquad;
    public static int CurrentLevel => _currentLevel;
    public static int LevelsCompleted => _levelsCompleted;
    public static int Money => _money;

    private static int _currentLevel;
    private static int _levelsCompleted;
    private static int _money;
    private static List<PoliceMan> _soldiersOnLevelStart = new List<PoliceMan>();
    private static List<PoliceMan> _soldiersInSquad = new List<PoliceMan>();

    public static void TransferSquad(List<PoliceMan> policeMen)
    {
        _soldiersInSquad = policeMen;
    }

    public static void ChangeMoney(int money)
    {
        _money += money;
    }

    public static void RepeatLevel()
    {
        if (_soldiersOnLevelStart.Count != 0)
        {
            _soldiersInSquad = _soldiersOnLevelStart;
        }
        else
        {
            _soldiersInSquad = new List<PoliceMan>();
        }
    }

    public static void ClearSquad()
    {
        _soldiersInSquad.Clear();
    }

    public static void AddSoldiers(List<PoliceMan> soldiers)
    {
        _soldiersInSquad = soldiers;
    }

    public static void AppointLevel(int currentLevel, int levelCompleted)
    {
        _currentLevel = currentLevel;
        _levelsCompleted = levelCompleted;
    }

    public static void AddAliveSoldiers(List<PoliceMan> soldiers)
    {
        _soldiersInSquad = soldiers;
    }
}
