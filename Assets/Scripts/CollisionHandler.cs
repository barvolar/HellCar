using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.TryGetComponent(out Enemy enemy))
            enemy.Die();
    }
}
