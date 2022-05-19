using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseTeacherButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Teacher _teacher;
    [SerializeField] private StopTime _stopTime;

    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(_teacher.gameObject);
        Destroy(_stopTime.gameObject);
        Destroy(gameObject);
    }
}
