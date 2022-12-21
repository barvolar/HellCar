using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private LayerMask _targetmast;
    [SerializeField] private float _radius;

    private Collider[] _colliders;
    void Update()
    {
        _colliders = Physics.OverlapSphere(transform.position, _radius, _targetmast);

        foreach (var item in _colliders)
        {
            if (item.TryGetComponent<Body>(out Body body))
                Debug.Log(item.name + " - " + Vector3.Distance(transform.position, item.transform.position));
        }
      
    }
}
