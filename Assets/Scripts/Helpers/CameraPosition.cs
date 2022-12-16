using UnityEngine;

namespace Helpers
{
    public class CameraPosition : MonoBehaviour
    {
        private Collider _collider;
        private bool _isCorrect = false;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            var wall = GameObject.Find("WallForDistanceCamera");
            _collider = wall.GetComponent<Collider>();
        }

        private void Update()
        {
            var bounds = _collider.bounds;
            var frustums = GeometryUtility.CalculateFrustumPlanes(_camera);
            if (_isCorrect)
            {
                return;
            }
            if (!GeometryUtility.TestPlanesAABB(frustums, bounds))
            {
                var vector = _camera.transform.position;
                vector.z -= 1;
                _camera.transform.position = vector;
                return;
            }

            _isCorrect = true;


        }
    }
}
