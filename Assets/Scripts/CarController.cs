using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Range(0, 1)][SerializeField] private float _rotationDelta;
    [SerializeField] private float _breakSpeed;
    [SerializeField] private float _speed;

    [SerializeField] private Transform _transfromWheelFL;
    [SerializeField] private Transform _transfromWheelFR;
    [SerializeField] private Transform _transfromWheelBL;
    [SerializeField] private Transform _transfromWheelBR;

    [SerializeField] private WheelCollider _wheelFL;
    [SerializeField] private WheelCollider _wheelFR;
    // [SerializeField] private WheelCollider _wheelBL;
    // [SerializeField] private WheelCollider _wheelBR;

    private float _velocity;
    private Vector3 _direction;

    private void Update()
    {
        ProcessValue();
        Rotation();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessValue()
    {
        _direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _velocity = Mathf.Sqrt(Mathf.Abs(_direction.x) + Mathf.Abs(_direction.z));
    }

    private void Rotation()
    {
        Quaternion targetRotation = Quaternion.LookRotation(_direction);
        if (_direction == Vector3.zero)
            targetRotation = transform.rotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationDelta * Time.deltaTime);
    }

    private void Move()
    {
        _wheelFL.motorTorque = _velocity * _speed;
        _wheelFR.motorTorque = _velocity * _speed;

        if (_direction == Vector3.zero || _wheelFL.rpm >= 1000f)
        {
            _wheelFL.brakeTorque = _breakSpeed;
            _wheelFR.brakeTorque = _breakSpeed;
        }
        else
        {
            _wheelFL.brakeTorque = 0;
            _wheelFR.brakeTorque = 0;
        }
    }
}
