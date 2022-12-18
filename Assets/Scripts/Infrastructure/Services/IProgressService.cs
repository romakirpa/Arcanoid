using System;

namespace Infrastructure.Services
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