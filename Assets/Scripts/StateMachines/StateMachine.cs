using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    private State _currentState;
    private Soldier _target;

    public void Init(Soldier target)
    {
        _target = target;
        Reset(_firstState);
    }

    private void Start()
    {
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }

    private void OnDisable()
    {
        _currentState.Exit();
    }

    private void Reset(State startState)
    {

            if (_currentState != null)
                _currentState.Exit();
            _currentState = startState;

            if (_currentState != null)
                _currentState.Enter(_target);

    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }

}
