using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceDistance;

    private Vector3 _moveDirection = Vector3.forward;
    private MeshRenderer _meshRenderer;
    private float _speed;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();   
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Segment>(out Segment segment))
        {
            segment.Break();
            Destroy(gameObject);
        }
        if (other.gameObject.TryGetComponent <Obstacle>(out Obstacle obstacle))
        {
            Bounce();
        }
    }

    private void Bounce()
    {
        _moveDirection = Vector3.back + Vector3.up;
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.isKinematic = false;
        rigidBody.AddExplosionForce(_bounceForce, transform.position + new Vector3(0, -1, 1), _bounceDistance);
    }
    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }
}
