using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    [SerializeField] private CloseShop _closeShop;
    [SerializeField] private Money _money;
    [SerializeField] private AudioClip _clickSound;
    private IconBuy _iconBuy;
    private AudioSource _audioSource;

    private void OnEnable()
    {
        _audioSource = GetComponentInParent<AudioSource>();
        _iconBuy = GetComponentInParent<IconBuy>();
    }

    public void OnBuyClick()
    {
        _audioSource.PlayOneShot(_clickSound);
        _iconBuy.BuySoldier();
        _money.Change(-_iconBuy.TotalPrice);
        _closeShop.Close();
    }
}
