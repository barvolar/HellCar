using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEnemy : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _copacity;

    private List<Enemy> _pool = new List<Enemy>();

    protected void Initialization(Enemy[] enemyTemplates, Player target)
    {
        for (int i = 0; i < enemyTemplates.Length; i++)
        {
            for (int j = 0; j < _copacity; j++)
            {
                Enemy spawnedEnemy = Instantiate(enemyTemplates[i], _container.transform);

                if (spawnedEnemy.TryGetComponent(out Enemy enemy))
                    enemy.SetTarget(target);

                spawnedEnemy.gameObject.SetActive(false);

                _pool.Add(spawnedEnemy);
            }
        }
    }

    protected bool TryGetRandomObject(out Enemy resul)
    {
        resul = _pool[Random.Range(0, _pool.Count)];
        
        if (resul.gameObject.activeSelf == false)
            return resul != null;
        else
            return resul = null;
    }

    public void DisableAllObjects()
    {
        foreach (var item in _pool)
        {
            item.gameObject.SetActive(false);
        }
    }
}
