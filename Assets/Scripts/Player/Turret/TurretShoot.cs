using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private GameObject _bulletContainer;
    [SerializeField] private GameObject _shootPoint;

    private List<Bullet> _bullets=new List<Bullet>();

    private int _copacity = 20;
    private float _damage = 10f;

    private void Awake()
    {
        CreateBullet();
    }

    private void CreateBullet()
    {
        for (int i = 0; i < _copacity; i++)
        {
            Bullet bullet = Instantiate(_bulletTemplate, _bulletContainer.transform);
            bullet.SetDamage(_damage);
            _bullets.Add(bullet);
            bullet.gameObject.SetActive(false);
        }
    }

    public void Shoot(Vector3 direction)
    {
        foreach (var item in _bullets)
        {
            if(item.gameObject.activeSelf == false)
            {
                item.gameObject.SetActive(true);
                item.transform.position = _shootPoint.transform.position;
                item.SetDirection(_shootPoint.transform.forward);
                break;
            }
        }
    }
}
