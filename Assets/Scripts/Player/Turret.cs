using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private Transform _body;
    [SerializeField] private Transform _gun;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private LayerMask _layerMaskEnemy;

    private Collider[] _colliders;
    private Transform _currentTarget;

    private void Update()
    {
        _colliders = Physics.OverlapSphere(transform.position, 1000f, _layerMaskEnemy);

        foreach (var hitCollider in _colliders)
        {
            if (hitCollider.TryGetComponent(out EnemyBody enemy))
            {
                if (GetDistance(_currentTarget) > (GetDistance(enemy.transform)) || _currentTarget == null)
                    _currentTarget = enemy.transform;
            }
        }
        LookAt();
    }

    private void LookAt()
    {
        if (_currentTarget == null)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(_currentTarget.position-transform.position);
        Vector3 rotation = lookRotation.eulerAngles;
        _body.rotation = Quaternion.Euler(0, rotation.y, 0);
        _gun.localRotation = Quaternion.Euler(rotation.x, 0, 0);
    }

    private float GetDistance(Transform target)
    {
        float distance;
        if (target == null)
            distance = 0;
        else
            distance = Vector3.Distance(target.position, transform.position);

        return distance;
    }
}
