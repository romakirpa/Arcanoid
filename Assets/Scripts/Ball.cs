using Blocks;
using Helpers;
using Infrastructure;
using Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private float _speed;
    private Vector3 _direction;
    private bool _isMoving;
    private float _currentDamage;
    private IProgressService _progressService;
    private Vector3 _startPosition;

    public void StartMove()
    {
        _isMoving = true;
    }

    private void Start()
    {
        _startPosition = transform.position;
        _rigidBody = GetComponent<Rigidbody>();
        _progressService = DiContainer.GetInstance<IProgressService>();
        _speed = 20f;
        _currentDamage = 1;
        PrepareBallToStart();
    }

    private Vector3 GetRandomDirection()
    {
        var random = new System.Random();

        var list = new int[] { -1, 1 };
        var number = list.OrderBy(x => random.Next()).First();
        return new Vector3(number, 1, this.transform.position.z);
    }

    private void FixedUpdate()
    {
        if (!_isMoving)
        {
            return;
        }
        _rigidBody.velocity = _direction * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var block = collision.gameObject.GetComponent<IBlock>();
        block?.Hit(_currentDamage);
        if (collision.gameObject.CompareTag(Constants.DeathLine))
        {
            Failed();
        }
        ChangeDirection(collision.contacts[0].normal);
    }

    private void ChangeDirection(Vector3 normal)
    {
        var ricochet = Vector2.Reflect(_direction, normal);
        _direction = ricochet;
    }

    private void PrepareBallToStart()
    {
        _isMoving = false;
        transform.position = _startPosition;
        _rigidBody.velocity = Vector3.zero;
        _direction = GetRandomDirection();
    }

    private void Failed()
    {
        _progressService.DecrementHealth();
        PrepareBallToStart();
    }
}