using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{  
    protected float Speed;
    protected int Health;
    protected int Money;
    protected int Damage;
    protected bool IsDie;

    public NavMeshAgent NavMeshAgent { get; protected set; }
    public Player Target { get; protected set; }
    public Animator Animator { get; protected set; }

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
