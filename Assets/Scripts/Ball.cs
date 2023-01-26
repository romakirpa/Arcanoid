using Blocks;
using Infrastructure;
using Infrastructure.Services.Interfaces;
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

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _speed = 20f;
        _currentDamage = 1;
        _direction = GetRandomDirection();
    }
    private Vector3 GetRandomDirection()
    {
        var random = new System.Random();

        var list = new int[] {-1, 1};
        
        return new Vector3(random.Next(list.Count()), 1, this.transform.position.z);
    }

    private void FixedUpdate()
    {
        if (!_isMoving)
        {
            return;
        }
        _rigidBody.velocity = _direction  * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var block = collision.gameObject.GetComponent<IBlock>();
        block?.Hit(_currentDamage);
        ChangeDirection(collision.contacts[0].normal);
    }

    private void ChangeDirection(Vector3 normal)
    {
        var ricochet = Vector2.Reflect(_direction, normal);
        _direction = ricochet;
    }

    public void StartMove()
    {
        _isMoving = true;
    }

    public void Failed()
    {
        _progressService = DiContainer.GetInstance<IProgressService>();
        _progressService.DecrementHealth();
        
        if (_progressService.HealthCount <= 0)
        {
            //todo implement end game;
            Application.Quit();
            return;
        }
    }
}