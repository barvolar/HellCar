using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTransition : Transition
{
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
}
