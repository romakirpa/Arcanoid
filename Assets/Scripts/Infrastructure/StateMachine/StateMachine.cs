using System;
using System.Collections.Generic;

namespace Infrastructure.StateMachine
{
    public class StateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _currentState;

        public StateMachine()
        {
            _states = new Dictionary<Type, IState>()
            {
                { typeof(BootState), new BootState(this) }
            };
        }

        public void EnterToState<TState>() where TState : IState
        {
            var state = _states[typeof(TState)];
            if (state != _currentState && _currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = state;
            state.Enter();
        }

        public void ExitFromState()
        {
            _currentState?.Exit();
        }
    }
}