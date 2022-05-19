using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    public Parametr parametr;
    [SerializeField] private float _maxValue;
    [SerializeField] private Slider _slider;
    private Coroutine _coroutine;


    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
    }

    public enum Parametr
    {
        Range = 1,
        RateOfFire = 2,
        CapacityAmmo = 3,
        Damage = 4
    }

    public void ChangeValue(float value)
    {
        float targetValue = value / _maxValue;
        if(_coroutine != null)
        {
            StopValueChanged(_coroutine);
        }
        _coroutine = StartCoroutine(SoftChange(targetValue));
    }

    private IEnumerator SoftChange(float value)
    {
        while(_slider.value!= value)
        {
            _slider.value =Mathf.Lerp(_slider.value, value , 0.01f);
            yield return null;
        }
        StopValueChanged(_coroutine);
    }

    private void StopValueChanged(Coroutine coroutine)
    {
        StopCoroutine(coroutine);
        _coroutine = null;
    }
}
