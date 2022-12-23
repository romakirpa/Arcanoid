using Infrastructure.Services.Interfaces;

namespace Infrastructure.StateMachine
{
    public class LoadLvlState :IParameterableState
    {
        public void Enter(string parameter)
        {
            var sceneLoader = DIConteiner.GetInstance<ISceneLoaderService>();
            sceneLoader.LoadScene(parameter);
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}