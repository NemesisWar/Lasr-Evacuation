using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fraction : ShootGunBullet
{
    private void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(Damage);
                DestroyBullet();
            }
            if (other.TryGetComponent(out Civilian civilian))
            {
                civilian.TakeDamage(Damage);
                DestroyBullet();
            }
        }
    }
}
