using Assets.Scripts.Infrastructure.Services.Interfaces;
using Infrastructure;
using Infrastructure.Services.Interfaces;
using UnityEngine;

public class Lift : MonoBehaviour
{
    private IInputService _inputService;
    private float _speed = 15f;
    private float _maxLeftPosition;
    private float _maxRightPosition;
    
    public void SetupMaxLiftPositions(Vector3 left, Vector3 right)
    {
        var halfLiftSize = gameObject.GetComponent<Renderer>().bounds.size.x / 2;
        _maxLeftPosition = left.x + halfLiftSize;
        _maxRightPosition = right.x - halfLiftSize;
    }

    private void Start()
    {
        _inputService = DiContainer.GetInstance<IInputService>();
    }

    private void Update()
    {
        var horizontalDirection = _inputService.GetAxis().x;
        transform.Translate(Vector3.right * horizontalDirection * _speed * Time.deltaTime);
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, _maxLeftPosition, _maxRightPosition);
        transform.position = pos;
    }
}
