using Helpers;
using UnityEngine;

namespace Assets.Scripts.Generators
{
    public class HealthMonitorGenerator
    {
        private Vector3 _top;
        private Vector3 _left;

        public HealthMonitorGenerator(Vector3 top, Vector3 left) 
        {
            _top = top;
            _left = left;
        }

        public void Generate()
        {
            var prefab = Resources.Load($"Prefabs/{Constants.Health}") as GameObject;
            var collider = prefab.GetComponent<BoxCollider>();
            var position = GetPosition(collider);
            prefab.transform.position = position;
            GameObject.Instantiate(prefab);
        }

        private Vector3 GetPosition(BoxCollider collider)
        {
            var x = _left.x + collider.size.x / 2;
            var y = _top.y - collider.size.y / 2;
            return new Vector3(x,y, _top.z);
        }
    }
}
