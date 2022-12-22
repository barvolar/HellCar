using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _nextState;
    [SerializeField] protected LayerMask SearchMask;
    [SerializeField] protected float SearchRadius;

    protected Collider[] Collisions;
    protected Player Target { get; private set; }
    protected NavMeshAgent NavMeshAgent { get; private set; }

    public State NextState => _nextState;

    public bool NeedTransite { get; protected set; }

    public void Init(Player target, NavMeshAgent agent)
    {
        Target = target;
        NavMeshAgent = agent;
    }

    private void OnEnable()
    {
        NeedTransite = false;
    }
}
