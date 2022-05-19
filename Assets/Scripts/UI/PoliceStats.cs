using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceStats : MonoBehaviour
{
    private Shop _shop;
    private List<Stat> _stats = new List<Stat>();
    private PoliceMan _policeMan;

    private void Awake()
    {
        _shop = GetComponentInParent<Shop>();
        _stats.AddRange(GetComponentsInChildren<Stat>());
    }

    private void OnEnable()
    {
        _shop.ChangeMan += Show;
    }

    private void OnDisable()
    {
        _shop.ChangeMan -= Show;
    }

    private void Show(PoliceMan policeMan)
    {
        foreach (var stat in _stats)
        {
            if (stat.parametr.ToString() == "Range")
                stat.ChangeValue(policeMan.Prefab.AttackRange);
            if (stat.parametr.ToString() == "RateOfFire")
                stat.ChangeValue(60f / policeMan.Prefab.Delay);
            if (stat.parametr.ToString() == "CapacityAmmo")
                stat.ChangeValue(policeMan.Prefab.MaxCapacityAmmo);
            if (stat.parametr.ToString() == "Damage")
                stat.ChangeValue(policeMan.Prefab.Damage);
        }
    }
}
