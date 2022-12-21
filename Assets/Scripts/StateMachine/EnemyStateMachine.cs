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

    private void Start()
    {
        _player = GetComponent<Enemy>().Target;
        _navMeshAgent = GetComponent<Enemy>().NavMeshAgent;

        Reset(_startState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        State nextState = _currentState.GetNextState();

        if (_currentState != null)
            Transite(nextState);
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        Debug.Log(_currentState.name + "!!!!!!");

        if (_currentState != null)
        {
            _currentState.Enter(_player, _navMeshAgent);
        }
    }

    private void Transite(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_player,_navMeshAgent);
    }
}
