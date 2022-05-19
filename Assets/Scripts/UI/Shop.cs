using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ShopCell> _shopCell = new List<ShopCell>();
    [SerializeField] private PoliceMan _choosenMan;
    public event UnityAction<PoliceMan> ChangeMan;

    private void Awake()
    {
        _shopCell.AddRange(GetComponentsInChildren<ShopCell>());
    }

    private void OnEnable()
    {
        AddSubscrible(_shopCell);
    }

    private void OnDisable()
    {
        RemoveSubscrible(_shopCell);
    }

    private void AddSubscrible(List<ShopCell> shopCell)
    {
        foreach (var cell in shopCell)
        {
            cell.Choose += OnChoose;
        }
    }

    private void RemoveSubscrible(List<ShopCell> shopCell)
    {
        foreach (var cell in shopCell)
        {
            cell.Choose -= OnChoose;
        }
    }

    private void OnChoose(PoliceMan policeMan)
    {
        if (policeMan != null)
        {
            _choosenMan = policeMan;
            ChangeMan?.Invoke(_choosenMan);
        }
    }


}
