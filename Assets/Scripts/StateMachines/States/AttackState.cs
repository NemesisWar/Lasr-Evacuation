using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField]private Enemy _zombie;

    private void Start()
    {
        _zombie = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        Animator.SetFloat("Attack", Vector3.Distance(transform.position, Target.transform.position));
    }

    private void OnDisable()
    {
        Animator.SetFloat("Attack", 0.0f);
    }

    private void Update()
    {
        _zombie.TryAttack(Target);
    }
}
