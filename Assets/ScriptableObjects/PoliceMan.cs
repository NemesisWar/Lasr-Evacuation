using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New PoliceMan", menuName ="PoliceMan/New Man", order = 51)]
public class PoliceMan : ScriptableObject
{
    public Sprite Icon => _icon;
    public Soldier Prefab => _prefab;
    public string Name => _name;
    public int Price => _price;
    public int Index => _index;

    [SerializeField] private Sprite _icon;
    [SerializeField] private Soldier _prefab;
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private int _index;
}
