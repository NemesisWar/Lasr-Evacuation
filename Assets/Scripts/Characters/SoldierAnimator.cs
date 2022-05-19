using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SoldierAnimator : MonoBehaviour
{
    private Animator _animator;
    private Soldier _soldier;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _soldier = GetComponent<Soldier>();
    }

    private void OnEnable()
    {
        _soldier.Shooting += OnShoot;
        _soldier.ReloadRifle += OnReload;
        _soldier.TargetLocked += OnTargetLock;
    }

    private void OnDisable()
    {
        _soldier.Shooting -= OnShoot;
        _soldier.ReloadRifle -= OnReload;
        _soldier.TargetLocked -= OnTargetLock;
    }

    private void OnShoot(bool action)
    {
        _animator.SetBool("Fire", action);
    }

    private void OnReload(bool action)
    {
        _animator.SetBool("Reload", action);
    }

    private void OnTargetLock(bool action)
    {
        _animator.SetBool("TargetLocked", action);
    }
}
