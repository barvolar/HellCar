using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private int _money = 0;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
            Debug.Log("Смерть");
    }

    public void AddMoney(int money)
    {
        _money += money;
    }
}
