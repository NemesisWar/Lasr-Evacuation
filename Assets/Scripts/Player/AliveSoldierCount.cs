using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveSoldierCount : MonoBehaviour
{
    [SerializeField] private List<PoliceMan> _aliveSoldiers;

    private void OnDisable()
    {
        _aliveSoldiers.AddRange(GetComponentsInChildren<PoliceMan>());
        if (_aliveSoldiers.Count != 0)
        {
            Player.AddAliveSoldiers(_aliveSoldiers);
        }
    }
}
