using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ScaleWithResolutuon : MonoBehaviour
{
    [SerializeField] private float _horizontalFieldOfView;
    private Camera _camera;
    private void Start()
    {
        _camera = GetComponent<Camera>();
        _camera.fieldOfView = 2 * Mathf.Atan(Mathf.Tan(_horizontalFieldOfView * Mathf.Deg2Rad * 0.5f) / _camera.aspect) * Mathf.Rad2Deg;
    }
}