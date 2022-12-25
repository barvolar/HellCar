using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyDieState : State
{
    private EnemyRagdol _ragdol;
    private float _lifeTime = 0;
    private float _maxLifeTime = 3f;

    private void OnEnable()
    {
        Process();
        Target.AddMoney(GetComponent<Enemy>().Money);
    }

    private void Start()
    {
        Process();
    }

    private void Update()
    {
        if (_ragdol.enabled == false)
            return;

        _lifeTime += Time.deltaTime;

        if (_lifeTime >= _maxLifeTime)
            gameObject.SetActive(false);
    }

    private void Process()
    {
        Animator.enabled = false;
        _ragdol = GetComponent<PoliceMan>().Ragdol;
        _ragdol.Enable();
    }
}
