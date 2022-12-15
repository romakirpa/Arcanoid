using System;
using DefaultNamespace;
using Infrastructure.Services;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

namespace Infrastructure
{
    public class Game
    {
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
                DIConteiner.RegisterType<IInputService>(new DefaultInputService());            }
            else
            {
                DIConteiner.RegisterType<IInputService>(new MobileInputService());            }
        }
    }
}