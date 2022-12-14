using System;
using Infrastructure.Services;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

namespace Infrastructure
{
    public class Game
    {
        public static IInputService InputService; // todo remove static, use DI in the future.
        public static int Health; // todo remove static, use DI.
        public static event Action MinusHealth;
        

        public Game()
        {
            RegisterInputService();
            Health = 3;
        }

        public static void DecrementHealth()
        {
            Health -= 1;
            if (MinusHealth != null) MinusHealth();
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