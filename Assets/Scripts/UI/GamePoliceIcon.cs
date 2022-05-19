using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class GamePoliceIcon : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AudioClip _clickSound;
    public PoliceMan PoliceMan => _man;
    public event UnityAction<GamePoliceIcon> ChoosedPolice;
    private PoliceMan _man;
    private Image _image;
    private GameSquad _gameSquad;
    private RectTransform _rectTransform;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponentInParent<AudioSource>();
        _gameSquad = GetComponentInParent<GameSquad>();
        _rectTransform = GetComponent<RectTransform>();
        gameObject.SetActive(IconStatus());
    }

    public void SetMan(PoliceMan man)
    {
        _man = man;
        _image = GetComponentInChildren<Image>();
        _image.sprite = _man.Icon;
        gameObject.SetActive(IconStatus());
    }

    private bool IconStatus()
    {
        return _man != null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _audioSource.PlayOneShot(_clickSound);
        ChoosedPolice?.Invoke(this);
        ChangeScale(1.3f);
    }

    public void ChangeScale(float scale)
    {
        _rectTransform.DOScale(scale, 0.5f);
    }
}
