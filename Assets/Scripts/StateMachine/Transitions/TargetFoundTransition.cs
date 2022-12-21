using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFoundTransition : Transition
{
    [SerializeField] private LayerMask _searchMask;

    private float _searchRadius;
    private Collider[] _collisions;
    private float _minRadius = 1.5f;
    private float _maxRadius = 0.5f;

    private void Start()
    {
        _searchRadius = Random.Range(_minRadius,_maxRadius);
    }

    private void Update()
    {
        _collisions = Physics.OverlapSphere(transform.position, _searchRadius, _searchMask);

        foreach (var collision in _collisions)
        {
            if (collision.TryGetComponent(out Body body))
            {
                NeedTransite = true;
            }              
        }
    }
}
