using UnityEngine;

namespace Assets.Scripts.Generators
{
    public class WallsGenerator
    {
        private Vector3 _topCenterPoint;
        private Vector3 _downCenterPoint;
        private Vector3 _leftCenterPoint;
        private Vector3 _rightCenterPoint;

        public WallsGenerator(Vector3 topCenterPoint,
                                  Vector3 downCenterPoint,
                                  Vector3 leftCenterPoint,
                                  Vector3 rightCenterPoint)
        {
            _topCenterPoint = topCenterPoint;
            _downCenterPoint = downCenterPoint;
            _leftCenterPoint = leftCenterPoint;
            _rightCenterPoint = rightCenterPoint;
        }

        public void GenerateWalls()
        {
            CreateTopWall();
            CreateRightWall();
            CreateDownWall();
            CreateLeftWall();
        }

        private void CreateLeftWall()
        {
            var sizeVerticalWall = Vector3.Distance(_downCenterPoint, _topCenterPoint);
            var left = GenerateWall(new Vector3(1, sizeVerticalWall, 1), "left");
            left.transform.position = new Vector3(_leftCenterPoint.x - (left.GetComponent<Collider>().bounds.size.x / 2), _leftCenterPoint.y, _leftCenterPoint.z);
        }

        private void CreateDownWall()
        {
            var sizeHorizontalWall = Vector3.Distance(_leftCenterPoint, _rightCenterPoint);
            var down = GenerateWall(new Vector3(sizeHorizontalWall, 1, 1), "down");
            down.transform.position = new Vector3(_downCenterPoint.x, _downCenterPoint.y - (down.GetComponent<Collider>().bounds.size.y / 2), _downCenterPoint.z);
            down.GetComponent<Renderer>().enabled = false;
        }

        private void CreateRightWall()
        {
            var sizeVerticalWall = Vector3.Distance(_downCenterPoint, _topCenterPoint);
            var right = GenerateWall(new Vector3(1, sizeVerticalWall, 1), "right");
            right.transform.position = new Vector3(_rightCenterPoint.x + (right.GetComponent<Collider>().bounds.size.x / 2), _rightCenterPoint.y, _rightCenterPoint.z);
        }

        private void CreateTopWall()
        {
            var sizeHorizontalWall = Vector3.Distance(_leftCenterPoint, _rightCenterPoint);
            var top = GenerateWall(new Vector3(sizeHorizontalWall, 1, 1), "top");
            top.transform.position = new Vector3(_topCenterPoint.x, _topCenterPoint.y + (top.GetComponent<Collider>().bounds.size.y / 2), _topCenterPoint.z);
        }

        private GameObject GenerateWall(Vector3 scale, string name)
        {
            var wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall.transform.localScale = scale;
            return wall;
        }
    }
}
