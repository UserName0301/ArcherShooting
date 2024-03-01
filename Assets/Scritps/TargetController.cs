using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float _minSpeed;
    public float _maxSpeed;

    float _currentSpeed;
    float _speedFalling = 3f;
    bool _isFalling;
    Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _currentSpeed = Random.Range(_minSpeed, _maxSpeed);
    }

    private void Update()
    {
        if(!_isFalling && _rb != null)
        {
            _rb.velocity = Vector2.down*_currentSpeed;
        }
    }

    public void Fall()
    {
        _isFalling = true;

        if(_rb != null)
        {
            _rb.isKinematic = false;
            _rb.velocity = Vector2.down * _speedFalling;
        }
    }
}
