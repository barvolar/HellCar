using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerHandler : MonoBehaviour
{
    public event UnityAction<float> Hits;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            Hits?.Invoke(bullet.Damage);
            bullet.gameObject.SetActive(false);
        }                 
    }

    private void OnTriggerExit(Collider other)
    {
       
    }
}
