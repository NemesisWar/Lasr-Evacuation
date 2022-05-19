using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Scaning : MonoBehaviour
{
    [SerializeField] private LayerMask _detectsOnLayers;
    [SerializeField] private float _radius;
    [SerializeField] private int _maxVisibleObjects;
    [SerializeField] private float _updateInterval;

    private List<GameObject> _visibleObjects = new List<GameObject>();
    private float _currentTime = 0f;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _updateInterval)
        {
            GetVisibleObject();
            _currentTime = 0f;
        }
    }

    private void GetVisibleObject()
    {
        _visibleObjects.Clear();

        Collider[] hitColliders = new Collider[_maxVisibleObjects];
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, _radius, hitColliders, _detectsOnLayers);

        for (int i = 0; i < numColliders; i++)
            _visibleObjects.Add(hitColliders[i].gameObject);
    }

    public GameObject TryGetNearestVisibleObject()
    {
        GetVisibleObject();
        GameObject result = null;

        if (_visibleObjects.Count != 0)
            result = _visibleObjects.OrderBy(a => Vector3.Distance(a.transform.position, transform.position)).First();

        return result;
    }

    public bool PesonIsTarget(GameObject target)
    {
        if (_visibleObjects.Contains(target))
            return true;
        else
            return false;
    }
}
