using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transitions> _transotoins;
    protected Soldier Target { get; set; }
    protected Animator Animator;

    public void Enter(Soldier target)
    {
        Animator = GetComponent<Animator>();
        if(enabled == false)
        {
            Target = target;
            enabled = true;
            foreach (var transition in _transotoins)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transotoins)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transotoins)
        {
            if (transition.NeedTransit == true)
                return transition.TargetState;
        }

        return null;
    }
}
