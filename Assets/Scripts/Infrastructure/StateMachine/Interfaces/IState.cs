namespace Infrastructure.StateMachine.Interfaces
{
    public interface IState: IExitable
    {
        void Enter();
    }
}