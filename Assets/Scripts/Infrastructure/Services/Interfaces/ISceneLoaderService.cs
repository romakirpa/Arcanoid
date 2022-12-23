using System;

namespace Infrastructure.Services.Interfaces
{
    public interface ISceneLoaderService
    {
        void LoadScene(string scene, Action OnLoaded = null);
    }
}