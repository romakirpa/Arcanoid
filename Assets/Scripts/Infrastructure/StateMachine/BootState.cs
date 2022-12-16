using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.StateMachine
{
    public class BootState : IState
    {
        private readonly StateMachine _stateMachine;

        public BootState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            RegisterService();
        }

        public void Exit()
        {
        }

        private void RegisterService()
        {
            if (Application.isEditor)
            {
                DIConteiner.RegisterType<IInputService>(new DefaultInputService());
            }
            else
            {
                DIConteiner.RegisterType<IInputService>(new MobileInputService());
            }
        }
    }
}