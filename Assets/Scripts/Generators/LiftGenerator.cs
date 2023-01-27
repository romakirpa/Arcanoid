using Helpers;
using UnityEngine;

namespace Assets.Scripts.Generators
{
    public class LiftGenerator
    {
        private Vector3 _leftCenterPoint;
        private Vector3 _rightCenterPoint;
        private Vector3 _downCenterPoint;

        public LiftGenerator(Vector3 leftCenterPoint, Vector3 rightCenterPoint, Vector3 downCenterPoint)
        {
            _leftCenterPoint = leftCenterPoint;
            _rightCenterPoint = rightCenterPoint;
            _downCenterPoint = downCenterPoint;
        }

        public GameObject GenerateLift()
        {
            var prefab = Resources.Load($"Prefabs/{Constants.LiftName}") as GameObject;
            var position = GetPosition(prefab.GetComponent<Renderer>().bounds.size.y);
            prefab.transform.position = position;
            var lift = GameObject.Instantiate(prefab);
            lift.GetComponent<Lift>().SetupMaxLiftPositions(_leftCenterPoint, _rightCenterPoint);
            return lift;
        }

        private Vector3 GetPosition(float liftSize) 
        {
            var x = _leftCenterPoint.x + ((_rightCenterPoint.x - _leftCenterPoint.x) / 2);
            var y = _downCenterPoint.y + (liftSize * 2);
            var z = _downCenterPoint.z;
            return new Vector3(x, y, z);
        }
    }
}
