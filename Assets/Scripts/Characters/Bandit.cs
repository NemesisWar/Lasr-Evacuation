using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : Enemy
{
    [SerializeField] private ParticleSystem _shootEffect;
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private Bullet _bullet;
    protected override void Attack(Soldier target)
    {
        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
        Bullet bullet = Instantiate(_bullet, _shootPoint.transform.position, Quaternion.identity);
        bullet.Init(target.transform);
        _shootEffect.Play(true);
    }
}
