using Infrastructure.Services.Interfaces;
using Infrastructure.StateMachine.Interfaces;

namespace Infrastructure.StateMachine
{
    public class LoadLvlState : IParameterableState
    {
        private readonly StateMachine _stateMachine;

        public LoadLvlState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Enter(string parameter)
        {
            var sceneLoader = DiContainer.GetInstance<ISceneLoaderService>();
            sceneLoader.LoadScene(parameter);
            _stateMachine.EnterToState<LoopState>();
        }

        public void Exit()
        {
        }
    }
}