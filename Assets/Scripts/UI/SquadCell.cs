using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SquadCell : MonoBehaviour, IPointerClickHandler
{
    public PoliceMan PoliceMan => _policeMan;
    public event UnityAction <SquadCell> ChoosePerson;
    [SerializeField] private Sprite _defaultSprite;
    private Image _image;
    [SerializeField] private PoliceMan _policeMan;
    [SerializeField] private AudioClip _clickSound;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponentInParent<AudioSource>();
        _image = GetComponent<Image>();
        if (_image.sprite == null)
            _image.sprite = _defaultSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _audioSource.PlayOneShot(_clickSound);
        ChoosePerson?.Invoke(this);
    }

    public void AssignCharacter(PoliceMan policeMan)
    {
        _policeMan = policeMan;
        _image.sprite = _policeMan.Icon;
    }
}
