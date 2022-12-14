using UnityEngine;

namespace Infrastructure.Services
{
    public class DefaultInputService : IInputService
    {
        public Vector2 GetAxis() 
            => new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}