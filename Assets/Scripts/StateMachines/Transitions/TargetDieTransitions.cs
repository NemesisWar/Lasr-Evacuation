using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDieTransitions : Transitions
{
    private void Update()
    {
        if (Target == null)
            NeedTransit = true;
    }
}
