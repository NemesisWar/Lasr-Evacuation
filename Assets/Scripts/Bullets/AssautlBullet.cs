using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssautlBullet : Bullet
{
    [SerializeField] private float _destroyTimer;
    private float _currentTime;
    public override void Init(Transform target)
    {
        transform.LookAt(new Vector3(target.position.x, target.position.y+1, target.position.z));
        _currentTime = 0;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _destroyTimer)
        {
            DestroyBullet();
        }
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer ==10)
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
