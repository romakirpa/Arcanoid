using Infrastructure.StateMachine.Interfaces;

namespace Infrastructure.StateMachine
{
    public class LoopState : IState
    {
        private readonly StateMachine _stateMachine;

        public LoopState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
        }
    }
}