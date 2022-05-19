using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public int MoneyCount => _money;
    [SerializeField] private int _money;
    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponentInChildren<TMP_Text>();
        UpdateCount();
    }

    public void UpdateCount()
    {
        _text.text = _money.ToString();
    }

    public void Change(int price)
    {
        _money += price;
        UpdateCount();
    }
}
