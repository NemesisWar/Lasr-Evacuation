using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DelayAnimation : MonoBehaviour
{
    private Animator _animator;
    private float _animatorSpeed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animatorSpeed = Random.Range(0.8f, 1.3f);
        _animator.speed = _animatorSpeed;
    }
}
