using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        var horizontalDirection = Input.GetAxis("Horizontal");
        _transform.Translate(Vector3.right * (horizontalDirection * _speed * Time.deltaTime));
    }
}
