using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveState : State
{  
    [SerializeField] private float _speed;
    [SerializeField] private float _speedSpreating;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _speed += Random.Range(-_speedSpreating, _speedSpreating);
    }

    private void OnEnable()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _speed;
        Animator.SetBool("Run", true);
        _navMeshAgent.enabled = true;
        Move();
    }

    private void OnDisable()
    {
        Animator.SetBool("Run", false);
        _navMeshAgent.enabled = false;
    }

    private void Move()
    {
        if (_navMeshAgent != null && Target != null)
        {
            _navMeshAgent.SetDestination(Target.transform.position);
            return;
        }

        //else
        //{
        //    Debug.Log("EVCP");
        //    _navMeshAgent.SetDestination();
        //    return;
        //}
    }
}
