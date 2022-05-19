using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public event UnityAction<int> SavedCivilians;
    public event UnityAction LevelFailed;
    [SerializeField] private List<Enemy> _zombieTemplates;
    [SerializeField] private List<Civilian> _civilianTemplates;
    [SerializeField] private List<Enemy> _enemysTemplates;
    [SerializeField] private Enemy _boss;
    [SerializeField] private int _maxZombieCounts;
    [SerializeField] private int _maxCivilianCounts;
    [SerializeField] private int _maxEnemyCounts;
    [SerializeField] private int _maxBossCounts;
    [SerializeField] private float _delayTime;
    private List<SpawnPoint> _points = new List<SpawnPoint>();
    private List<Soldier> _soldiers = new List<Soldier>();
    [SerializeField] private Transform _targetCivilian;
    private List<GameObject> _spawnObject = new List<GameObject>();
    private float _currentTime;
    private bool _spawnIsFinished = false;
    [SerializeField] private int _savedCivilian = 0;


    public void Init(Transform targetCivilian, List<Soldier> soldiers)
    {
        _points.AddRange(GetComponentsInChildren<SpawnPoint>());
        _targetCivilian = targetCivilian;
        _soldiers = soldiers;
        GivePersonsToSpawnPoint();
        SubscribleSoldier();
    }

    private void Start()
    {
        _points.AddRange(GetComponentsInChildren<SpawnPoint>());
        GivePersonsToSpawnPoint();
        SubscribleSoldier();
    }

    private void SubscribleSoldier()
    {
        foreach (var soldier in _soldiers)
        {
            soldier.Die += OnDieSoldier;
        }
    }

    private void UnSubscribleSoldier(Soldier soldier)
    {
        soldier.Die -= OnDieSoldier;
    }

    private void UnSubscribleEnemy(Enemy enemy)
    {
        enemy.Die -= OnDieEnemy;
        enemy.EnemyIsNull -= OnEnemyIsNull;
    }


    private void GivePersonsToSpawnPoint()
    {
        while (_maxZombieCounts!= 0)
        {
            GameObject person = Instantiate(_zombieTemplates[Random.Range(0, _zombieTemplates.Count)].transform.gameObject, _points[Random.Range(0, _points.Count)].transform.position, Quaternion.identity, transform);
            person.GetComponent<Enemy>().Init(_soldiers[Random.Range(0, _soldiers.Count)]);
            person.GetComponent<Enemy>().EnemyIsNull+=OnEnemyIsNull;
            person.GetComponent<Enemy>().Die+=OnDieEnemy;
            _spawnObject.Add(person);
            person.SetActive(false);
            _maxZombieCounts--;
        }

        while (_maxCivilianCounts != 0)
        {
            GameObject person = Instantiate(_civilianTemplates[Random.Range(0, _civilianTemplates.Count)].transform.gameObject, _points[Random.Range(0, _points.Count)].transform.position, Quaternion.identity, transform);
            person.GetComponent<Civilian>().Init(_targetCivilian);
            person.GetComponent<Civilian>().Saved += OnSavedCivilian;
            person.GetComponent<Civilian>().Die += OnDieCivilian;
            _spawnObject.Add(person);
            person.SetActive(false);
            _maxCivilianCounts--;
        }

        while (_maxEnemyCounts != 0)
        {
            GameObject person = Instantiate(_enemysTemplates[Random.Range(0, _enemysTemplates.Count)].transform.gameObject, _points[Random.Range(0, _points.Count)].transform.position, Quaternion.identity, transform);
            person.GetComponent<Enemy>().Init(_soldiers[Random.Range(0, _soldiers.Count)]);
            person.GetComponent<Enemy>().EnemyIsNull += OnEnemyIsNull;
            person.GetComponent<Enemy>().Die += OnDieEnemy;
            _spawnObject.Add(person);
            person.SetActive(false);
            _maxEnemyCounts--;
        }

        var result = _spawnObject.OrderBy(x => Random.Range(0, _spawnObject.Count)).ToList();
        _spawnObject = result;
        SpawnBoss();
    }

    private void SpawnBoss()
    {
        while (_maxBossCounts != 0)
        {
            GameObject person = Instantiate(_boss.transform.gameObject, _points[Random.Range(0, _points.Count)].transform.position, Quaternion.identity, transform);
            person.GetComponent<Enemy>().Init(_soldiers[Random.Range(0, _soldiers.Count)]);
            person.GetComponent<Enemy>().EnemyIsNull += OnEnemyIsNull;
            person.GetComponent<Enemy>().Die += OnDieEnemy;
            _spawnObject.Add(person);
            person.SetActive(false);
            _maxBossCounts--;
        }
    }

    private void Update()
    {
        if (_spawnIsFinished == false)
        {
            Spawn();
            return;
        }

        if (_spawnObject.Count == 0)
        {
            SavedCivilians?.Invoke(_savedCivilian);
            gameObject.SetActive(false);
        }
    }

    private void Spawn()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _delayTime)
        {
            _currentTime = 0;
            if(_spawnObject.FirstOrDefault(p => p.activeSelf == false))
            {
                GameObject enabledObject =  _spawnObject.FirstOrDefault(p => p.activeSelf == false);
                enabledObject.SetActive(true);
            }
            else
            {
                _spawnIsFinished = true;
            }
        }
    }

    private void OnSavedCivilian(Civilian civilian)
    {
        _savedCivilian++;
        _spawnObject.Remove(civilian.gameObject);
    }

    private void OnDieSoldier(Soldier soldier)
    {
        _soldiers.Remove(soldier);
        UnSubscribleSoldier(soldier);
        if (_soldiers.Count == 0)
            LevelFailed?.Invoke();
    }

    private void OnEnemyIsNull(Enemy zombie)
    {
        if (_soldiers.Count != 0)
        {
            zombie.Init(_soldiers[Random.Range(0, _soldiers.Count)]);
        }
        else
        {
            AllSoldiersDead(zombie);
        }
    }

    private void AllSoldiersDead(Enemy enemy)
    {
        enemy.Init(null);
        enemy.InitEvacuation(_targetCivilian);
        enemy.EnemyIsNull -= OnEnemyIsNull;
    }

    private void OnDieEnemy(Enemy enemy)
    {
        UnSubscribleEnemy(enemy);
        _spawnObject.Remove(enemy.gameObject);
        CheckNPSOnScene();
    }

    private void OnDieCivilian(Civilian civilian)
    {
        _spawnObject.Remove(civilian.gameObject);
        CheckNPSOnScene();
    }

    private void CheckNPSOnScene()
    {
        if (_spawnObject.Count == 0)
        {
            SavedCivilians?.Invoke(_savedCivilian);
            gameObject.SetActive(false);
        }
    }
}
