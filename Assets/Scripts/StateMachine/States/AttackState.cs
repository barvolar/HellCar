using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private string _attackBoolName = "IsAttack";

    private void Start()
    {
        if (Animator.GetBool(_attackBoolName) == false)
            Animator.SetBool(_attackBoolName, true);

        NavMeshAgent.isStopped = true;
    }

    private void OnEnable()
    {
        if (enabled == true)
        {
            if (NavMeshAgent.isStopped == false)
                NavMeshAgent.isStopped = true;
            Animator.SetBool(_attackBoolName, true);
        }
    }

    private void OnDisable()
    {
        NavMeshAgent.isStopped = false;
        Animator.SetBool(_attackBoolName, false);
    }

    public void Attack()
    {
        Debug.Log("Атакую - " + Target.name);
    }
}
