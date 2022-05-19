using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TargetButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _targetMark;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_targetMark.activeSelf == true)
        {
            _targetMark.SetActive(false);
            gameObject.layer = 9;
        }

        else
        {
            _targetMark.SetActive(true);
            gameObject.layer = 10;
        }
    }
}
