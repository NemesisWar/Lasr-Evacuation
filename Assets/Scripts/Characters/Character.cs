using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private GameObject _deadPrefab;
    public float Health => _health;
    public float Delay => _delay;
    public float AttackRange => _attackRange;

    protected float CurrentAttackTime;

    [SerializeField] private float _health;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _delay;


    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Instantiate(_deadPrefab, transform.position, transform.rotation);
            Death();
        }
    }

    protected abstract void Death();

}
