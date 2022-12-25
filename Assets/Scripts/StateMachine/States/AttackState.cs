using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class AttackState : State
{
    [SerializeField] private LayerMask _targetLayerMask;

    private string _attackBoolName = "IsAttack";
    private float _attackRange = 2.5f;

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
        Collider[] hits = Physics.OverlapSphere(transform.position, _attackRange, _targetLayerMask);

        foreach(var hit in hits)
        {
            if (hit.TryGetComponent(out Body body))
                Target.TakeDamage(GetComponent<Enemy>().Damage);
        }
    }
}
