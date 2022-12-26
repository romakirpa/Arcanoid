using System;
using System.Collections.Generic;
using Infrastructure.StateMachine.Interfaces;
using Interfaces;

namespace Infrastructure.StateMachine
{
    public class StateMachine
    {
        private Dictionary<Type, IExitable> _states;
        private IExitable _currentState;

        public StateMachine(ICoroutine coroutine)
        {
            _states = new Dictionary<Type, IExitable>()
            {
                { typeof(BootState), new BootState(this, coroutine) },
                { typeof(LoadLvlState), new LoadLvlState(this) },
                { typeof(LoopState), new LoopState(this) }
            };
        }

        public void EnterToState<TState>() where TState : IExitable
        {
            var state = _states[typeof(TState)] as IState;
            if (state != _currentState && _currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = state;
            state.Enter();
        }
        
        public void EnterToState<TState>(string parameter) where TState : IExitable
        {
            var state = _states[typeof(TState)] as IParameterableState;
            if (state != _currentState && _currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = state;
            state.Enter(parameter);
        }

        public void ExitFromState()
        {
            _currentState?.Exit();
        }
    }
}