using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceMan : Enemy
{
    [SerializeField] private Player _target;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        Init(_target,_navMeshAgent);
    }
}
