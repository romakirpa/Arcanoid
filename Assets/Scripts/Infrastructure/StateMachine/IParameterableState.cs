namespace Infrastructure.StateMachine
{
    public interface IParameterableState : IExitable
    {
        void Enter(string parameter);
    }
}