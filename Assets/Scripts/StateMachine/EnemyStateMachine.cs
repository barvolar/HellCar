using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private Player _player;
    private NavMeshAgent _navMeshAgent;
    private State _currentState;
    private Animator _animator;

    private void Start()
    {
        _player = GetComponent<Enemy>().Target;
        _navMeshAgent = GetComponent<Enemy>().NavMeshAgent;
        _animator = GetComponent<Enemy>().Animator;
        Reset(_startState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transite(nextState);
    }

    private void Reset(State startState)
    {
        _currentState = startState;
        if (_currentState != null)
        {
            _currentState.Enter(_player, _navMeshAgent,_animator);
        }
    }

    private void Transite(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_player,_navMeshAgent,_animator);
    }
}
