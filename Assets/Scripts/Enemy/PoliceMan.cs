using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceMan : Enemy
{
    [SerializeField] private Player _target;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField]private Animator _animator;
    [SerializeField] private LayerMask _searchMask;
    private void Awake()
    {
        Init(_target,_navMeshAgent,_animator);
    }

    private void Update()
    {
        Collider[] _collisions = Physics.OverlapSphere(transform.position, 5, _searchMask);
        foreach (var collision in _collisions)
        {
            Debug.Log(collision.name);
        }
    }
}
