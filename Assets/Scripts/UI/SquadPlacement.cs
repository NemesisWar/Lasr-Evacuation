using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SquadPlacement : MonoBehaviour
{
    public event UnityAction AwakeFinish;
    public List<PoliceMan> Squad => _squad;

    [SerializeField] private Button _playButton;
    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject _placeForSoldiers;
    private GameSquad _uiSquad;
    private List<PoliceMan> _squad = new List<PoliceMan>();
    private List<Soldier> _spawnedSoldier = new List<Soldier>();
    private int _soldierCount=>_squad.Count;
    private PoliceMan _selectedMan;

    private void Awake()
    {
        _uiSquad = GetComponent<GameSquad>();
        _squad = Player.SoldiersInSquad;
    }

    private void Start()
    {
        AwakeFinish?.Invoke();
    }

    private void OnEnable()
    {
        _uiSquad.SelectedMan += OnSelectedMan;
        _placeForSoldiers.SetActive(true);
    }

    private void OnDisable()
    {
        _uiSquad.SelectedMan -= OnSelectedMan;
        _placeForSoldiers.SetActive(false);
    }

    private void OnSelectedMan(PoliceMan policeMan)
    {
        _selectedMan = policeMan;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if(hit.transform.TryGetComponent(out SoldierPlace place) && _selectedMan != null)
                {
                    GameObject policeMan = Instantiate(_selectedMan.Prefab, transform.position, Quaternion.identity, _container.transform).gameObject;
                    RemoveSoldierFromSquad(_selectedMan);
                    place.Init(policeMan);
                }
            }
        }
    }

    private void RemoveSoldierFromSquad(PoliceMan policeMan)
    {
        _squad.Remove(policeMan);
        _uiSquad.DisableIcon();
        CheckSoldiers();
    }

    private void CheckSoldiers()
    {
        if (_soldierCount == 0)
            _playButton.gameObject.SetActive(true);
    }
}
