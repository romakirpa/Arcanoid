using Infrastructure.StateMachine;

namespace Infrastructure
{
    public class Game
    {
        public Game()
        {
            var stateMachine = new StateMachine.StateMachine();
            stateMachine.EnterToState<BootState>();
        }
    }
}