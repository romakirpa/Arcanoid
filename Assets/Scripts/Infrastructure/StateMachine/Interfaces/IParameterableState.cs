namespace Infrastructure.StateMachine.Interfaces
{
    public interface IParameterableState : IExitable
    {
        void Enter(string parameter);
    }
}