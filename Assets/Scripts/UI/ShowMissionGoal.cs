using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class ShowMissionGoal : MonoBehaviour
{
    [SerializeField] private string _missonGoal;
    [SerializeField] private float _timeShow;
    private Text _text;

    private void Start()
    {
        _text = GetComponentInChildren<Text>();
        ShowStartGoal();
    }
    public void ShowStartGoal()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_text.DOText(_missonGoal, _timeShow,true, ScrambleMode.All));
        sequence.Append(_text.DOText("",1f));
    }

    public void ShowGoal()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_text.DOText(_missonGoal, _timeShow));
        sequence.Append(_text.DOText("", 1, true, ScrambleMode.All));
    }
}
