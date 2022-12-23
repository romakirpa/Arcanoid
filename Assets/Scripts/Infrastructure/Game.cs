using Interfaces;

namespace Infrastructure
{
    public class Game
    {
        public StateMachine.StateMachine StateMachine;
        
        public Game(ICoroutine coroutine)
        {
            StateMachine = new StateMachine.StateMachine(coroutine);
        }
    }
}