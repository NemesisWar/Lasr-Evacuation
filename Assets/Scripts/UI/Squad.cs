using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Squad : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private IconBuy _iconBuy;
    private List<SquadCell> _squadCells = new List<SquadCell>();
    private Coroutine _coroutine;


    private void Awake()
    {
        _squadCells.AddRange(GetComponentsInChildren<SquadCell>());
    }

    private void OnEnable()
    {
        foreach (var cell in _squadCells)
        {
            cell.ChoosePerson += OnChoosePerson;
        }
    }

    private void OnDisable()
    {
        foreach (var cell in _squadCells)
        {
            cell.ChoosePerson -= OnChoosePerson;
        }
    }

    private void Start()
    {
        _coroutine = StartCoroutine(TransferSquard());
    }

    private void OnChoosePerson(SquadCell squadCell)
    {
        _iconBuy.AppointBuyCell(squadCell);
        _shop.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public List<PoliceMan> CurrentSquad()
    {
        List<PoliceMan> policeMen = new List<PoliceMan>();
        foreach (var cell in _squadCells)
        {
            if (cell.PoliceMan != null)
                policeMen.Add(cell.PoliceMan);
        }
        return policeMen;
    }

    private IEnumerator TransferSquard()
    {
        yield return new WaitForSeconds(0.5f);
        if (Player.SoldiersInSquad.Count == 0)
        {
            StopCoroutine(_coroutine);
        }
        int number = 0;
        foreach (var soldier in Player.SoldiersInSquad)
        {
            _squadCells[number].AssignCharacter(soldier);
            number++;
        }
        StopCoroutine(_coroutine);
    }
}
