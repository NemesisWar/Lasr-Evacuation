using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Rocket : Bullet
{
    [SerializeField] private float _radiusDamage;
    [SerializeField] private int _maxDamagedObjects;
    [SerializeField] private ParticleSystem _splash;
    [SerializeField] private LayerMask _detectsOnLayers;
    private Vector3 _destantion;
    private bool _isDestroyed = false;
    private AudioSource _audioSource;
    public override void Init(Transform target)
    {
        transform.LookAt(target);
        _destantion = target.transform.position;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isDestroyed == true)
            return;
        transform.position = Vector3.MoveTowards(transform.position, _destantion, Speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, _destantion) < 0.1f)
        {
            _isDestroyed = true;
            CreateSphereDamage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() || other.GetComponent<Civilian>())
        {
            CreateSphereDamage();
        }
    }

    private void CreateSphereDamage()
    {
        ParticleSystem splash = Instantiate(_splash, transform.position, Quaternion.identity);
        _audioSource.Play();
        Collider[] hitColliders = new Collider[_maxDamagedObjects];
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, _radiusDamage, hitColliders, _detectsOnLayers);
        for (int i = 0; i < numColliders; i++)
        {
            ToDamage(hitColliders[i]);
        }
        DestroyBullet();
    }

    private void ToDamage(Collider collider)
    {
        if (collider.TryGetComponent(out Enemy zombie))
        {
            zombie.TakeDamage(Damage);
        }
        if (collider.TryGetComponent(out Civilian civilian))
        {
            civilian.TakeDamage(Damage);
        }
    }
}
