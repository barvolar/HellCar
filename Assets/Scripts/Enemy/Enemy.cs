using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private TriggerHandler _triggerHandler;
    [SerializeField] private int _money;
    [SerializeField] private float _damage;

    [SerializeField] protected float Health;

    public int Money => _money;
    public float Damage => _damage;

    public event UnityAction Died;

    private void OnEnable()
    {
        _triggerHandler.Hits += OnHits;
    }

    private void OnDisable()
    {
        _triggerHandler.Hits -= OnHits;
    }

    protected float Speed;
    protected bool IsDie;

    public NavMeshAgent NavMeshAgent { get; protected set; }
    public Player Target { get; protected set; }
    public Animator Animator { get; protected set; }

    private void OnHits(float damage)
    {
        Health -= damage;

        if (Health <= 0)
            Died?.Invoke();
    }

    protected void Init(NavMeshAgent agent,Animator animator)
    {
        NavMeshAgent = agent;
        Animator = animator;
        IsDie = false;
    }  
    
    public void SetTarget(Player target)
    {
        Target = target;
    }
}
