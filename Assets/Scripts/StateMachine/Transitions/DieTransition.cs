using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTransition : Transition
{
   [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        _enemy.Died -= OnDied;
    }

    private void Update()
    {
        Collisions = Physics.OverlapSphere(transform.position, SearchRadius, SearchMask);
        foreach (var collision in Collisions)
        {
            if (collision.TryGetComponent(out Body body))
            {
                NeedTransite = true;
            }
        }
    }

    private void OnDied()
    {
        NeedTransite = true;
    }
}
