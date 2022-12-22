using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGoneTransition : Transition
{
    [SerializeField] private LayerMask _searchMask;
    [SerializeField] private float _searchRadius;

    private Collider[] _collisions;

    private void Update()
    {
        _collisions = Physics.OverlapSphere(transform.position, _searchRadius, _searchMask);
        if (_collisions.Length == 0)
        {
            NeedTransite = true;
        }
    }
}
