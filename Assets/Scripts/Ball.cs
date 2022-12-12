using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private float _speed;
    private Vector3 _direction;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _speed = 5;
        _direction = Vector3.up * _speed;
        //_direction = new Vector3(0, 1, 1);
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = _direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ChangeDirection(collision.contacts[0].normal);
    }

    private void ChangeDirection(Vector3 normal)
    {
        var ricochet = Vector2.Reflect(_direction, normal);
        _direction = ricochet;
    }
}
