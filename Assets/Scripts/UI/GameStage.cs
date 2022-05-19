using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStage : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _containerSoldiers;
    [SerializeField] private Transform _exitPoint;
    [SerializeField] private List<Soldier> _soldiers = new List<Soldier>();
    [SerializeField] private List<PoliceMan> _aliveSoldiers = new List<PoliceMan>();

    private void OnEnable()
    {
        _soldiers.AddRange(_containerSoldiers.GetComponentsInChildren<Soldier>());
        _spawner.Init(_exitPoint, _soldiers);
        _spawner.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        if (_soldiers.Count == 0)
            return;
        foreach (var soldier in _soldiers)
        {
            _aliveSoldiers.Add(soldier.PoliceMan);
        }
        Player.AddAliveSoldiers(_aliveSoldiers);
    }
}
