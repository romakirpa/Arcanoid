using Infrastructure;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using UnityEngine;

public class Lift : MonoBehaviour
{
    private IInputService _inputService;
    private float _speed = 15f;
    private Transform _transform;
    private float _maxLeftPosition;
    private float _maxRightPosition;
    private float _halfSize;

    void Start()
    {
        _inputService = DiContainer.GetInstance<IInputService>();
        _transform = GetComponent<Transform>();
        _halfSize = GetComponent<Renderer>().bounds.size.x / 2;
        _maxLeftPosition = GetMaxLeftPosition(); // todo refactor this
        _maxRightPosition = GetMaxRightPosition(); // todo refactor this
    }

    void Update()
    {
        var horizontalDirection = _inputService.GetAxis().x;
        _transform.Translate(Vector3.right * (horizontalDirection * _speed * Time.deltaTime));
        var pos = _transform.position;
        pos.x = Mathf.Clamp(pos.x, _maxLeftPosition, _maxRightPosition);
        _transform.position = pos;        
    }

    private float GetMaxLeftPosition()
    {
        var wall = GetWall("WallLeft");
        var leftWallPositionX = GetWallPositionX(wall);
        var result = leftWallPositionX + _halfSize + 
                      (wall.GetComponent<Collider>().bounds.size.x / 2);
        return result;
    }
    
    private float GetMaxRightPosition()
    {
        var wall = GetWall("WallRight");
        var rightWallPositionX = GetWallPositionX(wall);
        var result = rightWallPositionX - _halfSize - 
                     (wall.GetComponent<Collider>().bounds.size.x / 2);
        return result;
    }

    private GameObject GetWall(string gameObjectName)
    {
       return GameObject.Find(gameObjectName);
    }

    private float GetWallPositionX(GameObject wall)
    {
        return wall.transform.localPosition.x;
    }
}
