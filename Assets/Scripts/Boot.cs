using Infrastructure;
using Infrastructure.StateMachine;
using Interfaces;
using UnityEngine;

public class Boot : MonoBehaviour, ICoroutine
{
    private void Awake()
    {
        var game = new Game(this);
        game.StateMachine.EnterToState<BootState>();
        DontDestroyOnLoad(gameObject);
    }
}