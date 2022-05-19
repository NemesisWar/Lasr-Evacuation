using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseShop : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private Squad _squad;

    public void Close()
    {
        _squad.gameObject.SetActive(true);
        _shop.gameObject.SetActive(false);
    }
}
