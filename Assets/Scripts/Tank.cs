using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private float _timeBetweenShoot;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet[] _bullets;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _recoilDistance;

    private float _timeAfterLastShoot;

    private void Update()
    {
        _timeAfterLastShoot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (_timeAfterLastShoot > _timeBetweenShoot)
            {
                Shoot();
                transform.DOMoveZ(transform.position.z - _recoilDistance, _timeBetweenShoot / 2).SetLoops(2, LoopType.Yoyo);
            }
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(_bullets[UnityEngine.Random.Range(0, _bullets.Length)], _shootPoint.position, Quaternion.identity);
        bullet.SetSpeed(_bulletSpeed);
        //bullet.SetColor(UnityEngine.Random.ColorHSV(0, 1, 0.8f, 1, 0.8f, 1, 1, 1));
        _timeAfterLastShoot = 0;

    }
}
