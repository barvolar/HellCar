using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : PoolEnemy
{
    [SerializeField] private Enemy[] _templates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Player _target;
    [SerializeField] private float _timeBetweenSpawn;

    private float _elapsedTime;

    private void Awake()
    {
        Initialization(_templates, _target);
        _elapsedTime = _timeBetweenSpawn;
    }

    private void Update()
    {
        _elapsedTime += Time.fixedUnscaledDeltaTime;
        if (_elapsedTime >= _timeBetweenSpawn)
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
}
