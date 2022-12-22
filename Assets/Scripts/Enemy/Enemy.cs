using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float Speed;
    
    protected int Health;
    protected int Money;
    protected int Damage;
    protected bool IsDie;

    public NavMeshAgent NavMeshAgent { get; protected set; }
    public Player Target { get; protected set; }
    public Animator Animator { get; protected set; }

    protected void Init(Player target,NavMeshAgent agent,Animator animator)
    {
        NavMeshAgent = agent;
        Target = target;
        Animator = animator;
        IsDie = false;
    }
    protected  void Locomotion() { }

    protected  void AttackTarget() { }

    protected  void ProcessValue() { }

    public  void Die() { }
    
}
