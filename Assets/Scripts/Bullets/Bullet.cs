using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float Damage => _damage;

    [SerializeField] protected float Speed;
    [SerializeField] private float _damage;

    public abstract void Init(Transform target);

    protected void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
