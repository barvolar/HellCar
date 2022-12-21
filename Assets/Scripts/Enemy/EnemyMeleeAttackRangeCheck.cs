using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttackRangeCheck : MonoBehaviour
{
    private bool _isAttackRange = false;
    public bool IsRange => _isAttackRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out TakeDamageTrigger trigger))
            _isAttackRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out TakeDamageTrigger trigger))
            _isAttackRange = false;
    }
}
