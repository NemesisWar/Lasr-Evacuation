using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class EvacuationMover : MonoBehaviour
{
    private NavMeshAgent _navMesh;
    private Animator _animator;
    public void MoveOnEvacuation(Transform evacuationPoint)
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _navMesh.enabled = true;
        _animator.SetBool("Run", true);
        _navMesh.SetDestination(evacuationPoint.position);
    }
}
