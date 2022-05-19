using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkRate : MonoBehaviour
{
    private Light _light;
    private Component _halo;
    private float _delayEnable;
    private float _delayDisable;

    private void OnEnable()
    {
        _halo = GetComponent("Halo");
        _light = GetComponent<Light>();
        _delayEnable = Random.Range(0.5f, 5f);
        _delayDisable = Random.Range(0.2f, 1f);
        Coroutine coroutine = StartCoroutine(DisableDelay());
    }

    private IEnumerator DisableDelay()
    {
        while (true)
        {
            _light.enabled = true;
            _halo.GetType().GetProperty("enabled").SetValue(_halo, true, null);
            yield return new WaitForSeconds(_delayEnable);
            _light.enabled = false;
            _halo.GetType().GetProperty("enabled").SetValue(_halo, false, null);
            yield return new WaitForSeconds(_delayDisable);
        }
    }
}
