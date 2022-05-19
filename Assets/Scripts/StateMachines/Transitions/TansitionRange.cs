using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TansitionRange : Transitions
{
    private float _transitionRange;
    [SerializeField] private float _rangeSpreating;


    private void Start()
    {
        _transitionRange = Random.Range(GetComponent<Enemy>().AttackRange, _rangeSpreating);
    }

    private void Update()
    {
        if (Target == null)
            return;
        if (Vector3.Distance(transform.position, Target.transform.position) < _transitionRange)
        {
            NeedTransit = true;
        }
    }
}
