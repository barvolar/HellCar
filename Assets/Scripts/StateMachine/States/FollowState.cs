using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    private string _followBoolName = "IsFollow";

    private void Start()
    {
        if (Animator.GetBool(_followBoolName) == false)
            Animator.SetBool(_followBoolName, true);
    }

    private void OnEnable()
    {
        Animator.SetBool(_followBoolName, true);
    }

    private void Update()
    {
        NavMeshAgent.SetDestination(Target.transform.position);
    }

    private void OnDisable()
    {
        Animator.SetBool(_followBoolName, false);
    }
}
