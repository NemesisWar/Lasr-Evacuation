using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    [SerializeField] private float _damage;
    protected override void Attack(Soldier target)
    {
        target.TakeDamage(_damage);
    }
}
