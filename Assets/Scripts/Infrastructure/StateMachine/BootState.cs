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
            DIConteiner.RegisterType<IProgressService>(new ProgressService());
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