using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Player Target;
    protected NavMeshAgent NavMeshAgent;
    protected Animator Animator;
    protected string _currentStateTriggerName;

    public void Enter(Player target, NavMeshAgent agent,Animator animator)
    {
        if (enabled == false)
        {
            Target = target;
            NavMeshAgent = agent;
            Animator = animator;
            enabled = true;
            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target, NavMeshAgent);
            }
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransite)
                return transition.NextState;
        }

        return null;
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
                transition.enabled = false;

            enabled = false;
        }
    }
}
