using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class Civilian : Character
{
    public event UnityAction<Civilian> Die;
    public event UnityAction<Civilian> Saved;
    [SerializeField] private float _baseSpeed;
    [SerializeField] private float _speedSpread;
    [SerializeField] private Transform _target;
    private NavMeshAgent _navMeshAgent;

    public void Init(Transform target)
    {
        _target = target;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        _navMeshAgent.SetDestination(_target.transform.position);
        _navMeshAgent.speed = _baseSpeed + Random.Range(-_speedSpread, _speedSpread);
    }

    protected override void Death()
    {
        Die?.Invoke(this);
        Destroy(gameObject);
    }

    public void SavedPeople()
    {
        Saved?.Invoke(this);
        Destroy(gameObject);
    }
}
