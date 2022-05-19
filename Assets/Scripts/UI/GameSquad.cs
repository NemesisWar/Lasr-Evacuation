using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSquad : MonoBehaviour
{
    public event UnityAction<PoliceMan> SelectedMan;
    private List<GamePoliceIcon> _icons = new List<GamePoliceIcon>();
    private PoliceMan _policeMan;
    private SquadPlacement _squadPlacement;
    private GamePoliceIcon _currentIcon;

    private void Awake()
    {
        _squadPlacement = GetComponent<SquadPlacement>();
        _icons.AddRange(GetComponentsInChildren<GamePoliceIcon>());
        _squadPlacement.AwakeFinish += SetIcons;
    }

    private void OnEnable()
    {
        foreach (var icon in _icons)
        {
            icon.ChoosedPolice += OnChoosedPolice;
        }
    }

    private void OnDisable()
    {
        _squadPlacement.AwakeFinish -= SetIcons;
        foreach (var icon in _icons)
        {
            icon.ChoosedPolice -= OnChoosedPolice;
        }
    }

    private void OnChoosedPolice(GamePoliceIcon icon)
    {
        SetDefaultIconsSize();
        _currentIcon = icon;
        _policeMan = _currentIcon.PoliceMan;
        SelectedMan?.Invoke(_policeMan);
    }

    private void SetIcons()
    {
        List<PoliceMan> policeMen = new List<PoliceMan>();
        policeMen = _squadPlacement.Squad;
        for (int i = 0; i < policeMen.Count; i++)
        {
            _icons[i].SetMan(policeMen[i]);
        }
    }

    public void DisableIcon()
    {
        _currentIcon.gameObject.SetActive(false);
        _currentIcon = null;
    }

    private void SetDefaultIconsSize()
    {
        foreach (var icon in _icons)
        {
            icon.ChangeScale(1f);
        }
    }
}
