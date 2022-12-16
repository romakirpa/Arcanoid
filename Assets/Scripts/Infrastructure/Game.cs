using System;
using Infrastructure.StateMachine;

namespace Infrastructure
{
    public class Game
    {
        public static int Health; // todo remove static, use DI.
        public static event Action MinusHealth;
        

        public Game()
        {
            var stateMachine = new StateMachine.StateMachine();
            stateMachine.EnterToState<BootState>();
            Health = 3;
        }

        public static void DecrementHealth()
        {
            Health -= 1;
            if (MinusHealth != null) MinusHealth();
        }
    }
}