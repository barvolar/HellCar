using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdol : MonoBehaviour
{
    [SerializeField] Rigidbody[] _allRigidbody;
   // [SerializeField] Collider _myCollider;

    private void Awake()
    {
        foreach (var rb in _allRigidbody)
        {
            rb.isKinematic = true;
        }
    }

    public void Enable()
    {
       // _myCollider.isTrigger = true;
        for (int i = 0; i < _allRigidbody.Length; i++)
        {
            _allRigidbody[i].isKinematic = false;
        }
    }
}
