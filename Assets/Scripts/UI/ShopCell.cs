using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShopCell : MonoBehaviour, IPointerClickHandler
{
    public event UnityAction <PoliceMan> Choose;
    [SerializeField] private PoliceMan _policeMan;
    [SerializeField] private AudioClip _clickSound;
    private Image _sprite;
    private TMP_Text _text;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponentInParent<AudioSource>();
        _sprite = GetComponentInChildren<Image>();
        _sprite.sprite = _policeMan.Icon;
        _text = GetComponentInChildren<TMP_Text>();
        _text.text = _policeMan.Price.ToString() + "$";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _audioSource.PlayOneShot(_clickSound);
        Choose?.Invoke(_policeMan);
    }

}
