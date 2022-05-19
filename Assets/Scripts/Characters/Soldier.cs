using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Soldier : Character
{
    public event UnityAction<Soldier> Die;
    public event UnityAction<bool> TargetLocked;
    public event UnityAction<bool> ReloadRifle;
    public event UnityAction<bool> Shooting;
    public int MaxCapacityAmmo => _maxCapacityAmmo;
    public float Damage => _bullet.Damage;
    public PoliceMan PoliceMan => _policeMan;

    [SerializeField] private ParticleSystem _attackEffect;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private AudioClip _audioShoot;
    [SerializeField] private PoliceMan _policeMan;
    [SerializeField] private RelioadButton _reloadButton;
    [SerializeField] private int _maxCapacityAmmo;
    [SerializeField] private int _capacityAmmo;
    private float _reloadTime = 4.5f;
    private Scaning _scaning;
    private AudioSource _audioSource;
    private bool _canShoot = true;
    private GameObject _target;
    private Coroutine _coroutine;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _scaning = GetComponent<Scaning>();
    }

    private void Init(GameObject target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target == null)
            GetNewEnemy();
        CurrentAttackTime += Time.deltaTime;
        if (_target != null && _capacityAmmo != 0)
        {
            if (CurrentAttackTime >= Delay)
            {
                if(_scaning.PesonIsTarget(_target) == false)
                {
                    GetNewEnemy();
                }

                if ((Vector3.Distance(_target.transform.position, transform.position) <= AttackRange) && _canShoot == true)
                {
                    CurrentAttackTime = 0;
                    Shoot(_target.transform);
                    _capacityAmmo--;
                    if (_capacityAmmo == 0)
                    {
                        _reloadButton.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GetNewEnemy();
                    Shooting?.Invoke(false);
                }
            }
        }
        else
        {
            Shooting?.Invoke(false);
        }
    }

    private void GetNewEnemy()
    {
        _target = _scaning.TryGetNearestVisibleObject();
        TargetLocked?.Invoke(_target);
    }

    private void Shoot(Transform target)
    {
        Shooting?.Invoke(true);
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        Bullet bullet = Instantiate(_bullet, _shootPoint.transform.position, Quaternion.identity);
        bullet.Init(target);
        _attackEffect.Play(true);
        _audioSource.PlayOneShot(_audioShoot);
    }

    public void RealoadAmmo()
    {
        if (_coroutine != null)
        {
            ReloadFinish();
        }
        _coroutine = StartCoroutine(Reload());
    }

    protected override void Death()
    {
        Die?.Invoke(this);
        Destroy(gameObject);
    }

    private IEnumerator Reload()
    {
        ReloadRifle?.Invoke(true);
        yield return new WaitForEndOfFrame();
        ReloadRifle?.Invoke(false);
        yield return new WaitForSeconds(_reloadTime);
        _capacityAmmo = _maxCapacityAmmo;
    }

    private void ReloadFinish()
    {
        StopCoroutine(_coroutine);
        _coroutine = null;
    }
}
