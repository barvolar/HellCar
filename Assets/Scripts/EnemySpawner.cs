using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : PoolEnemy
{
    [SerializeField] private Wave[] _waves;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Player _target;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private int _spawnde;
    private float _elapsedTime;

    private void Awake()
    {
        SetWave(_currentWaveNumber);
        Initialization(_waves, _target);
    }

    private void Update()
    {
        _elapsedTime += Time.fixedUnscaledDeltaTime;

        if (_elapsedTime >= _currentWave.Delay)
        {
            if (TryGetRandomObject(out Enemy spawnedEnemy))
            {
                _elapsedTime = 0;

                int spawnPositionIndex = Random.Range(0, _spawnPoints.Length);

                spawnedEnemy.gameObject.SetActive(true);
                spawnedEnemy.transform.position = _spawnPoints[spawnPositionIndex].position;
            }
        }
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }
}

[System.Serializable]
public class Wave
{
    [SerializeField] private SpawnUnit[] _templates;
    [SerializeField] private float _delay;

    public float Delay => _delay;
    public SpawnUnit[] SpawnUnits => _templates;
}

[System.Serializable]
public class SpawnUnit
{
    [SerializeField] private Enemy _template;
    [SerializeField] private int _count;

    public Enemy Template => _template;
    public int Count => _count;
}

