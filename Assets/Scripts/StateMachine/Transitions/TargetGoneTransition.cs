using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGoneTransition : Transition
{
   // [SerializeField] private LayerMask _searchMask;
   // [SerializeField] private float _searchRadius;

 //   private Collider[] _collisions;

    private void Update()
    {
        Collisions = Physics.OverlapSphere(transform.position, SearchRadius, SearchMask);
        if (Collisions.Length == 0)
        {
            NeedTransite = true;
        }
    }
}
