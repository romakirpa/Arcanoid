using Infrastructure.Services.Interfaces;
using UnityEngine;

namespace Infrastructure.Services
{
    public class MobileInputService : IInputService
    {
        public Vector2 GetAxis()
        {
            var vector = new Vector2();
            if (Input.touchCount <= 0)
            {
                return vector;
            }

            var touch = Input.GetTouch(0);
            vector.x = touch.position.x < Screen.width / 2 ? -1f : 1f;
            vector.y = touch.position.y < Screen.height / 2 ? -1f : 1f;
            return vector;
        }
    }
}