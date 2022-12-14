using Infrastructure;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private float _speed;
    private Vector3 _direction;
    private Transform _transform;
    private bool _isMoving;
    private float _currentDamage;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _speed = 20f;
        _isMoving = true;
        _direction = Vector3.up * _speed;
        _currentDamage = 1;
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

    private void ToStartPosition()
    {
        _transform.position = new Vector3(0, 1.38f, 0);
        _isMoving = false;
    }

    public void StartMove()
    {
        _isMoving = true;
    }
}