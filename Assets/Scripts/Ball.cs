using Blocks;
using Infrastructure;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private float _speed;
    private Vector3 _direction;
    private bool _isMoving;
    private float _currentDamage;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _speed = 20f;
        _currentDamage = 1;
        RestartPosition();
    }

    private void FixedUpdate()
    {
        if (!_isMoving)
        {
            return;
        }

        _rigidBody.velocity = _direction;
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
        Game.Health -= 1;
        if (Game.Health <= 0)
        {
            //todo implement end game;
            Application.Quit();
            return;
        }
        RestartPosition();
    }

    private void RestartPosition()
    {
        _isMoving = false;
        transform.position = new Vector3(0f, 1f, 0);
        _direction = Vector3.up * _speed;
        _rigidBody.velocity = Vector3.zero;
        transform.rotation = new Quaternion();
    }
}