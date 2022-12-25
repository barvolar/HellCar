using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Turret : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private Transform _body;
    [SerializeField] private Transform _gun;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _shootSpeed;
    [SerializeField] private LayerMask _layerMaskEnemy;

    private TurretShoot _turretShoot;
    private Collider[] _colliders;
    private Transform _currentTarget;
    private float _time;

    public event UnityAction Fired;

    private void Start()
    {
        _turretShoot = GetComponent<TurretShoot>();
    }

    private void Update()
    {
        _time += Time.deltaTime;

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

        if (_currentTarget != null && _time >= _shootSpeed)
        {
            _turretShoot.Shoot(_currentTarget.position);
            Fired?.Invoke();
            _time = 0;
        }
    }

    private void LookAt()
    {
        if (_currentTarget == null)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(_currentTarget.position - transform.position);
        Vector3 rotation = lookRotation.eulerAngles;
        Quaternion targetRotationY = Quaternion.Euler(0, rotation.y, 0);

        _body.rotation = Quaternion.Slerp(_body.rotation, targetRotationY, _rotationSpeed * Time.deltaTime);
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
