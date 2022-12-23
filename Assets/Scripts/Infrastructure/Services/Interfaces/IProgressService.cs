using System;

namespace Infrastructure.Services.Interfaces
{
    public interface IProgressService
    {
        event Action OnDied;
        int HealthCount { get; }
        string LvlName { get; }
        void DecrementHealth();
        void IncrementHealth();
        void SetLvl(string lvlName);
    }
}