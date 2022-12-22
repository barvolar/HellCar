using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyDieState : State
{
    private EnemyRagdol _ragdol;

    private void OnEnable()
    {
        Process();
    }

    private void Start()
    {
        Process();
    }

    private void Process()
    {
        Animator.enabled = false;
        _ragdol = GetComponent<PoliceMan>().Ragdol;
        _ragdol.Enable();
    }
}
