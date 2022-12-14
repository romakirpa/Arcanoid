using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure
{
    public class Game
    {
        public static IInputService InputService; // todo remove static, use DI in the future.
        public static int Health; // todo remove static, use DI.

        public Game()
        {
            RegisterInputService();
            Health = 3;
        }

        private void RegisterInputService()
        {
            if (Application.isEditor)
            {
                InputService = new DefaultInputService();
            }
            else
            {
                InputService = new MobileInputService();
            }
        }
    }
}