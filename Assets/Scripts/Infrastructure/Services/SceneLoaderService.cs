using System;
using System.Collections;
using Infrastructure.Services.Interfaces;
using Interfaces;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services
{
    public class SceneLoaderService : ISceneLoaderService
    {
        private ICoroutine _coroutine;

        public SceneLoaderService(ICoroutine coroutine)
        {
            _coroutine = coroutine;
        }
        
        public void LoadScene(string scene, Action OnLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == scene)
            {
                OnLoaded?.Invoke();
                return;
            }

            _coroutine.StartCoroutine(Load(scene, OnLoaded));
        }
        
        private IEnumerator Load(string scene, Action OnLoaded = null)
        {
            var waitLoadScene = SceneManager.LoadSceneAsync(scene);
            while (!waitLoadScene.isDone)
            {
                yield return null;
            }
        }
    }
}