using Helpers;
using UnityEngine;

namespace Assets.Scripts.Generators
{
    public class BallGenerator
    {
        public void GenerateBall(Vector3 liftPosition)
        {
            var prefab = Resources.Load($"Prefabs/{Constants.BallName}") as GameObject;
            var ballSize = prefab.GetComponent<Renderer>().bounds.size.x;
            var ball = GameObject.Instantiate(prefab);
            ball.transform.position = GetPosition(ballSize, liftPosition);
        }

        private Vector3 GetPosition(float ballSize, Vector3 liftPosition)
        {
            var y = liftPosition.y + ballSize;
            return new Vector3(liftPosition.x, y, liftPosition.z);
        }
    }
}
