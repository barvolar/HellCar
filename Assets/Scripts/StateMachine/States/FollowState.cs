using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState :State
{
    [SerializeField] private float _speed;
    

    private void Update()
    {
        NavMeshAgent.SetDestination(Target.transform.position);
    }
}
