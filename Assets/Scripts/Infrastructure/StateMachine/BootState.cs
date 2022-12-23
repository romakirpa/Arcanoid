using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Interfaces;
using UnityEngine;

namespace Infrastructure.StateMachine
{
    public class BootState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly ICoroutine _coroutine;
        private string Lvl = "Lvl1";

        public BootState(StateMachine stateMachine, ICoroutine coroutine)
        {
            _stateMachine = stateMachine;
            _coroutine = coroutine;
        }

        public void Enter()
        {
            RegisterService();
            _stateMachine.EnterToState<LoadLvlState>(Lvl);
        }

        public void Exit()
        {
        }

        private void RegisterService()
        {
            DIConteiner.RegisterType<ISceneLoaderService>(new SceneLoaderService(_coroutine));
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