using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RelioadButton : MonoBehaviour, IPointerClickHandler
{
    private Soldier _soldier;
    [SerializeField] private float _rotateSpeed;


    private void Start()
    {
        _soldier = GetComponentInParent<Soldier>();
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, _rotateSpeed * Time.deltaTime, 0));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _soldier.RealoadAmmo();
        gameObject.SetActive(false);
    }
}
