using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transitions : MonoBehaviour
{
    public State TargetState => _targetState;
    public bool NeedTransit { get; protected set; }
    protected Soldier Target { get; private set; }
    [SerializeField] private State _targetState;

    public void Init(Soldier target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }

}
