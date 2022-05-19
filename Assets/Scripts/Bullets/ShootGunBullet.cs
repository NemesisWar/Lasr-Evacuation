using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGunBullet : Bullet
{
    [SerializeField] private float _destroyTimer;
    private float _currentTime;

    public override void Init(Transform target)
    {
        transform.LookAt(new Vector3(target.position.x, target.position.y + 1, target.position.z));
        _currentTime = 0;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _destroyTimer)
        {
            DestroyBullet();
        }
    }
}
