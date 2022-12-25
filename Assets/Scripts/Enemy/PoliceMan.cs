using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceMan : Enemy
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Animator _animator;
    [SerializeField] private LayerMask _searchMask;
 
    public EnemyRagdol Ragdol { get; private set; }

    private void Awake()
    {
        Ragdol = GetComponent<EnemyRagdol>();
        Init(_navMeshAgent, _animator);

    }
}
