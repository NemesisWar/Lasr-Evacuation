using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public abstract class Enemy : Character
{
    public event UnityAction<Enemy> EnemyIsNull;
    public event UnityAction<Enemy> Die;
    [SerializeField] private AudioClip _audioShoot;
    [SerializeField] private Soldier _target;
    private StateMachine _stateMachine;
    private AudioSource _audioSource;
    private EvacuationMover _evacuationMover;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _evacuationMover = GetComponent<EvacuationMover>();
    }

    public void Init(Soldier target)
    {
        _target = target;
        _stateMachine = GetComponent<StateMachine>();
        _stateMachine.Init(_target);
    }

    public void InitEvacuation(Transform evacuationPoint)
    {
        _stateMachine.enabled = false;
        _evacuationMover.enabled = true;
        _evacuationMover.MoveOnEvacuation(evacuationPoint);
    }

    public void TryAttack(Soldier target)
    {
        if (CurrentAttackTime>Delay)
        {
            CurrentAttackTime = 0;
            _audioSource.PlayOneShot(_audioShoot);
            Attack(target);
        }
    }

    protected override void Death()
    {
        Die?.Invoke(this);
        Destroy(gameObject);
    }

    protected abstract void Attack(Soldier target);

    private void Update()
    {
        CurrentAttackTime += Time.deltaTime;
        if (_target == null)
        {
            EnemyIsNull?.Invoke(this);
        }
    }

}
