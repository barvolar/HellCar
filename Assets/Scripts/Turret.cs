using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private Transform _body;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private LayerMask _layerMaskEnemy;

    private Collider[] _colliders;

    private void Start()
    {
        
    }

    private void Update()
    {
        _colliders = Physics.OverlapSphere(transform.position, 1000f, _layerMaskEnemy);

        foreach (var hitCollider in _colliders)
        {
            if (hitCollider.TryGetComponent(out Enemy enemy))
                if (_target == null)
                    _target = enemy.transform;
                else if (Vector3.Distance(enemy.transform.position, transform.position) < Vector3.Distance(_target.position, transform.position))
                    _target = enemy.transform;
        }

        Quaternion targetRotation = Quaternion.LookRotation(_target.position-transform.position);
        _body.transform.rotation = Quaternion.Lerp(_body.transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

   

}
